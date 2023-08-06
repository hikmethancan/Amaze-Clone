namespace Abstract.Base_Template
{
    public abstract class SavableEntity<T>
    {
        public int id;
        public string Key => typeof(T).Name;
        public virtual string GetKey()
        {
            return Key;
        }
    }
}