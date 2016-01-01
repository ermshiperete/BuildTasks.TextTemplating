using Microsoft.VisualStudio.TextTemplating;
using Mono.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTasks.TextTemplating
{
    internal class TemplateGeneratorSessionHost : TemplateGenerator, ITextTemplatingSessionHost
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
