namespace IV
{
    public abstract class linkList
    {
        linkList[] _parent;
        linkList[] _child;
        protected linkList(linkList[] parent, linkList[] child)
        {
            _parent = parent;
            _child = child;
        }
        linkList[] getParent()
        {
            return _parent;
        }
        linkList[] getChild()
        {
            return _child;
        }
    }
}
