using System;
using System.Collections.Generic;

// Interfaz común para todas las expresiones
public interface IExpression
{
    bool Interpret(string context);
}

// Expresión Terminal para verificar la disponibilidad de un artículo de ropa
public class ItemAvailabilityExpression : IExpression
{
    private string _item;

    public ItemAvailabilityExpression(string item)
    {
        _item = item;
    }

    public bool Interpret(string context)
    {
        // Simplemente verificamos si el artículo está disponible en el contexto
        return context.Contains(_item);
    }
}

// Expresión No Terminal para combinar expresiones utilizando el operador OR lógico
//estas clases representan las expresiones  terminales  utilizadas para evaluar la disponibilidad e los articulos
public class OrExpression : IExpression
{
    private IExpression _leftExpression;
    private IExpression _rightExpression;

    public OrExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public bool Interpret(string context)
    {
        // Evaluamos ambas expresiones y aplicamos la operación OR
        return _leftExpression.Interpret(context) || _rightExpression.Interpret(context);
    }
}

// Contexto que almacena el estado de disponibilidad de los artículos de ropa

public class ClothingContext
{
    private Dictionary<string, int> _availableItems;

    public ClothingContext(Dictionary<string, int> availableItems)
    {
        _availableItems = availableItems;
    }

    public int GetItemQuantity(string item)
    //para obtener la cantidad de  unidades disponibles
    {
        return _availableItems.ContainsKey(item) ? _availableItems[item] : 0;
    }

    public bool Evaluate(IExpression expression)
    //para evaluar la expresiones sobre el contexto
    {
        return expression.Interpret(string.Join(",", _availableItems.Keys));
    }
}