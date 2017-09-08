namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
        public Passenger Passenger { get; protected set; }

        protected PassengerNode()
        {
            
        }
        public PassengerNode(Node startNode, Node endNode, Passenger passenger)
        {
            StartNode = startNode;
            EndNode = endNode;
            Passenger = passenger;
        }
    }
}