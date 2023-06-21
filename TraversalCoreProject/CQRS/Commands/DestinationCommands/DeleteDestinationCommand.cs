namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationCommand
    {
        public DeleteDestinationCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
