using MediatR;

namespace PresentationLayer.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
    }
}
