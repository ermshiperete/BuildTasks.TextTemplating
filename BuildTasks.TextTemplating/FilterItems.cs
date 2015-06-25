// Copyright (c) 2015 SIL International
// This software is licensed under the MIT License (http://opensource.org/licenses/MIT)
using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BuildTasks.TextTemplating
{
	public class FilterItems: Task
	{
		public ITaskItem[] Include { get; set; }

		public ITaskItem[] Exclude { get; set; }

		public string MetadataName { get; set; }
		public string MetadataValue { get; set; }

		[Output]
		public ITaskItem[] Result { get; set; }

		public override bool Execute()
		{
			if (Include == null || Include.Length == 0)
				return true;

			var output = new List<ITaskItem>();
			foreach (var matchedItem in Include)
			{
				var metadata = matchedItem.GetMetadata(MetadataName);
				if (string.IsNullOrEmpty(metadata))
					continue;
				if (!string.IsNullOrEmpty(MetadataValue) && metadata != MetadataValue)
					continue;

				output.Add(matchedItem);
			}

			Result = output.ToArray();

			return true;
		}
	}
}
