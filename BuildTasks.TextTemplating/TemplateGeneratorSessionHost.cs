using Microsoft.VisualStudio.TextTemplating;
using Mono.TextTemplating;

namespace BuildTasks.TextTemplating
{
	class TemplateGeneratorSessionHost : TemplateGenerator, ITextTemplatingSessionHost
	{
		public ITextTemplatingSession Session { get; set; }

		public ITextTemplatingSession CreateSession()
		{
			return Session = new TemplateGeneratorSession();
		}

		public TemplateGeneratorSessionHost()
		{
			CreateSession();
		}
	}
}
