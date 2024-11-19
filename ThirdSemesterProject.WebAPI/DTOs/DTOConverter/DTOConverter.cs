using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebAPI.DTOs.DTOConverter;

public static class DTOConverter
{
    public static SaleOrder FromDTO(this SaleOrderDTO saleOrderDTOToConvert )
    {
        var saleOrder = new SaleOrder();
        saleOrderDTOToConvert.CopyPropertiesTo(saleOrder);
        return saleOrder;
    }
}
