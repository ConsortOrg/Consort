namespace CursePaint.Actions
{
    public class NullAction : IAction
    {
        public string Name => "No Action";
        public bool CanDo => false;
        public bool CanUndo => false;
        public void Do() { }
        public void Undo() { }
    }
}
