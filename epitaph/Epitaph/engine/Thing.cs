using System.Collections.Generic;
using System.Numerics;

namespace Epitaph;



public enum SpaceType
{
    Objective,
    Relative
}



public class Thing
{
    public string name;

    public Matrix4x4 objectiveSpace;

    public Thing? parent;
    public List<Thing> children;

    public List<string> tags;



    public Thing(Matrix4x4? space = null, Thing? parent = null, List<Thing>? children = null, string name = "Stract", List<string>? tags = null, SpaceType spaceType = SpaceType.Objective, bool root = false)
    {
        if (name == null) { this.name = "Thing"; } else { this.name = name; }
        
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



        if (children == null) { this.children = new List<Thing>(); } else { this.children = children; }



    }



    // Hierachy management

    public void SetParent(Thing newParent)
    {
        if (this.parent != null)
        {
            this.parent.children.Remove(this);
        }

        this.parent = newParent;

        newParent.children.Add(this);
    }

    public void AddChild(Thing newChild)
    {
        if (newChild.parent != null)
        {
            newChild.parent.children.Remove(newChild);
        }

        newChild.parent = this;

        this.children.Add(newChild);
    }

    public void RemoveChild(Thing childToRemove)
    {
        
    }

    public void RemoveChild(int childIndex)
    {

    }



    // Hierachal searching

    public List<Thing> GetChildren()
    {
        return this.children;
    }

    public List<Thing> GetSubthings()
    {
        List<Thing> subthings = new List<Thing>();

        foreach (Thing child in this.children)
        {
            Console.WriteLine($"looking at child {child.name}");
            subthings.Add(child);

            foreach (Thing subthing in child.GetSubthings())
            {
                Console.WriteLine($"Looking at child {subthing.name}");
                subthings.Append(subthing);
            }
        }

        return subthings;
    }



    public List<Thing> GetChildrenWithTag(string tag)
    {
        List<Thing> childrenWithTag = new List<Thing>();

        foreach (Thing child in this.children)
        {
            if (child.tags.Contains(tag))
            {
                childrenWithTag.Add(child);
            }
        }

        return childrenWithTag;
    }

    public List<Thing> GetSubthingsWithTag(string tag)
    {
        List<Thing> subthingsWithTag = new List<Thing>();

        foreach (Thing child in this.children)
        {
            if (child.tags.Contains(tag))
            {
                subthingsWithTag.Add(child);
            }

            foreach (Thing substract in child.GetSubthingsWithTag(tag))
            {
                subthingsWithTag.Add(substract);
            }
        }

        return subthingsWithTag;
    }



    public List<Thing> GetChildrenOfType(Type type)
    {
        List<Thing> childrenOfType = new List<Thing>();

        foreach (Thing child in this.children)
        {
            if (child.GetType() == type)
            {
                childrenOfType.Add(child);
            }
        }

        return childrenOfType;
    }

    public List<Thing> GetSubsthingsOfType(Type type)
    {
        List<Thing> subthingsOfType = new List<Thing>();

        foreach (Thing child in this.children)
        {
            if (child.GetType() == type)
            {
                subthingsOfType.Add(child);
            }

            foreach (Thing substract in child.GetSubsthingsOfType(type))
            {
                subthingsOfType.Add(substract);
            }
        }

        return subthingsOfType;
    }
    


}
