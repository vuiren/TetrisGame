namespace TetrisGame
{
    internal class Field
    {
        public FieldSettings fieldSettings;
        public bool[,] field;

        public Field(FieldSettings fieldSettings)
        {
            this.fieldSettings = fieldSettings;
            field = new bool[fieldSettings.Width, fieldSettings.Height];
        }
    }
}
