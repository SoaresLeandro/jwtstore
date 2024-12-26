namespace JwtStore.Core.SharedContext.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        public Guid Id { get; set; }

        public bool Equals(Guid id) => Id == id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
