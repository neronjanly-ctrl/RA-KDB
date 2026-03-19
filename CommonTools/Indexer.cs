using System;

namespace CommonTools;

public class Indexer<TArgument, TValue>
{
    public Func<TArgument, TValue> Getter { get; set; }
    public Action<TArgument, TValue> Setter { get; set; }

    public TValue this[TArgument arg]
    {
        get
        {
            return Getter(arg);
        }

        set
        {
            Setter(arg, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TValue>
{
    public Func<TArgument1, TArgument2, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2]
    {
        get
        {
            return Getter(arg1, arg2);
        }

        set
        {
            Setter(arg1, arg2, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3]
    {
        get
        {
            return Getter(arg1, arg2, arg3);
        }

        set
        {
            Setter(arg1, arg2, arg3, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TArgument4, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TArgument4, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TArgument4, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3, TArgument4 arg4]
    {
        get
        {
            return Getter(arg1, arg2, arg3, arg4);
        }

        set
        {
            Setter(arg1, arg2, arg3, arg4, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3, TArgument4 arg4, TArgument5 arg5]
    {
        get
        {
            return Getter(arg1, arg2, arg3, arg4, arg5);
        }

        set
        {
            Setter(arg1, arg2, arg3, arg4, arg5, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3, TArgument4 arg4, TArgument5 arg5, TArgument6 arg6]
    {
        get
        {
            return Getter(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        set
        {
            Setter(arg1, arg2, arg3, arg4, arg5, arg6, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3, TArgument4 arg4, TArgument5 arg5, TArgument6 arg6, TArgument7 arg7]
    {
        get
        {
            return Getter(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        set
        {
            Setter(arg1, arg2, arg3, arg4, arg5, arg6, arg7, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3, TArgument4 arg4, TArgument5 arg5, TArgument6 arg6, TArgument7 arg7, TArgument8 arg8]
    {
        get
        {
            return Getter(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        set
        {
            Setter(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, value);
        }
    }
}

public class Indexer<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TValue>
{
    public Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TValue> Getter { get; set; }
    public Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TArgument9, TValue> Setter { get; set; }

    public TValue this[TArgument1 arg1, TArgument2 arg2, TArgument3 arg3, TArgument4 arg4, TArgument5 arg5, TArgument6 arg6, TArgument7 arg7, TArgument8 arg8, TArgument9 arg9]
    {
        get
        {
            return Getter(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        set
        {
            Setter(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, value);
        }
    }
}
