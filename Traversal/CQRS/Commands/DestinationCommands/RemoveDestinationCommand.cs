namespace PresentationLayer.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int destinationId)
        {
            DestinationId = destinationId;
        }
        public int DestinationId { get; set; }
    }
}
