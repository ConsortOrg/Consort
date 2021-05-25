namespace CursePaint.Actions
{
    public interface IAction
    {
        public string Name { get; }
        public bool CanDo { get; }
        public bool CanUndo { get; }
        public void Do();
        public void Undo();
    }
}
