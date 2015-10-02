// Copyright (c) 2015 SIL International
// This software is licensed under the MIT License (http://opensource.org/licenses/MIT)
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Mono.TextTemplating;
using System.CodeDom.Compiler;

namespace BuildTasks.TextTemplating
{
	public class TransformTemplates: Task
	{
		public ITaskItem[] TemplatesToProcess { get; set; }
		public ITaskItem[] OutputFiles { get; set; }
		public bool MinimalRebuildFromTracking { get; set; }

		[Output]
		public ITaskItem[] GeneratedFiles { get; set; }

		public override bool Execute()
		{
			if (TemplatesToProcess == null || OutputFiles == null)
				return true;

			var retVal = true;
			var generator = new TemplateGenerator();
			var output = new List<ITaskItem>();

			for (int i = 0; i < Math.Min(TemplatesToProcess.Length, OutputFiles.Length); i++)
			{
				if (MinimalRebuildFromTracking)
				{
					var source = new FileInfo(TemplatesToProcess[i].ItemSpec);
					var dest = new FileInfo(OutputFiles[i].ItemSpec);
					if (source.LastWriteTimeUtc <= dest.LastWriteTimeUtc)
					{
						Log.LogMessage(MessageImportance.Low,
							"Skipping template '{0}' because its outputs are up-to-date.",
							TemplatesToProcess[i].ItemSpec);
						continue;
					}
				}
				Log.LogMessage(MessageImportance.Low, "Processing template '{0}' into '{1}'",
					TemplatesToProcess[i].ItemSpec, OutputFiles[i].ItemSpec);
				generator.ProcessTemplate(TemplatesToProcess[i].ItemSpec, OutputFiles[i].ItemSpec);
				if (generator.Errors.HasErrors)
				{
					Log.LogError("Processing '{0}' failed.", TemplatesToProcess[i].ItemSpec);
					foreach (CompilerError error in generator.Errors)
					{
						Log.LogError("{0}({1},{2}): {3} {4}: {5}", Path.GetFileName(error.FileName),
							error.Line, error.Column, error.IsWarning ? "warning" : "error",
							error.ErrorNumber, error.ErrorText);
					}
					retVal = false;
				}
				output.Add(OutputFiles[i]);
			}
			GeneratedFiles = output.ToArray();
			return retVal;
		}
	}
}
