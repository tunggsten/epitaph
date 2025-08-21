using System.Collections.Generic;
using System.Numerics;

namespace Epitaph;



public enum SpaceType
{
    Objective,
    Relative
}



public class Stract
{
    public string name;

    private Matrix4x4 objectiveSpace;

    private Stract? parent;
    private List<Stract> children;

    public List<string> tags;



    public Stract(Matrix4x4? space = null, Stract? parent = null, List<Stract>? children = null, string name = "Stract", List<string>? tags = null, SpaceType spaceType = SpaceType.Objective, bool root = false)
    {
        if (parent == null)
        {
            if (root)
            {
                this.parent = null;
                Engine.root = this;
            }
            else
            {
                SetParent(Engine.root);
            }
        }
        else
        {
            SetParent(parent);
        }



        if (spaceType == SpaceType.Objective)
        {
            if (space == null) { this.objectiveSpace = Matrix4x4.Identity; } else { this.objectiveSpace = (Matrix4x4)space; }
        }
        else
        {
            if (space == null) { this.objectiveSpace = this.parent.objectiveSpace; } else { /* do the goofy ahh space shit here */ }
        }



        if (children == null) { this.children = new List<Stract>(); } else { this.children = children; }



    }



    // Hierachy management

    public void SetParent(Stract newParent)
    {
        if (this.parent != null)
        {
            this.parent.children.Remove(this);
        }

        this.parent = newParent;

        newParent.children.Add(this);
    }

    public void AddChild(Stract newChild)
    {
        if (newChild.parent != null)
        {
            newChild.parent.children.Remove(newChild);
        }

        newChild.parent = this;

        this.children.Add(newChild);
    }

    public void RemoveChild(Stract childToRemove)
    {

    }

    public void RemoveChild(int childIndex)
    {

    }



    // Hierachal searching

    public List<Stract> GetChildren()
    {
        return this.children;
    }

    public List<Stract> GetSubstracts()
    {
        List<Stract> substracts = new List<Stract>();

        foreach (Stract child in this.children)
        {
            substracts.Add(child);

            foreach (Stract substract in child.GetSubstracts())
            {
                substracts.Append(substract);
            }
        }

        return substracts;
    }



    public List<Stract> GetChildrenWithTag(string tag)
    {
        List<Stract> childrenWithTag = new List<Stract>();

        foreach (Stract child in this.children)
        {
            if (child.tags.Contains(tag))
            {
                childrenWithTag.Add(child);
            }
        }

        return childrenWithTag;
    }

    public List<Stract> GetSubstractsWithTag(string tag)
    {
        List<Stract> substractsWithTag = new List<Stract>();

        foreach (Stract child in this.children)
        {
            if (child.tags.Contains(tag))
            {
                substractsWithTag.Add(child);
            }

            foreach (Stract substract in child.GetSubstractsWithTag(tag))
            {
                substractsWithTag.Add(substract);
            }
        }

        return substractsWithTag;
    }



    public List<Stract> GetChildrenOfType(Type type)
    {
        List<Stract> childrenOfType = new List<Stract>();

        foreach (Stract child in this.children)
        {
            if (child.GetType() == type)
            {
                childrenOfType.Add(child);
            }
        }

        return childrenOfType;
    }

    public List<Stract> GetSubstractsOfType(Type type)
    {
        List<Stract> substractsOfType = new List<Stract>();

        foreach (Stract child in this.children)
        {
            if (child.GetType() == type)
            {
                substractsOfType.Add(child);
            }

            foreach (Stract substract in child.GetSubstractsOfType(type))
            {
                substractsOfType.Add(substract);
            }
        }

        return substractsOfType;
    }
    


}
