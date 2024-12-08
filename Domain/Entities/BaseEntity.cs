namespace Domain.Entities;
/// <summary>
///  Базовая сущность
/// </summary>
public class BaseEntity
{
    /// <summary>
    ///  Идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }

    
    
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// Сравниение по id
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if(obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        var id = ((BaseEntity)obj).Id;

        return id == Id;
    }

    protected bool Equals(BaseEntity other)
    {
        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        return left.Equals(right);
    }

    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        return !(left == right);
    }
}