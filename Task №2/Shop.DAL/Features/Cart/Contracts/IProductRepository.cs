namespace Shop.DAL.Features.Cart.Contracts
{
    interface IProductRepository
    {
        bool Add();
        bool Remove();
        bool Update();
        bool Contains();
        bool Search();
    }
}
