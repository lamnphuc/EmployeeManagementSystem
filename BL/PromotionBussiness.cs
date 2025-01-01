using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using TL;

namespace BL
{
    public class PromotionBusiness
    {
        private readonly PromotionData _promotionData;

        public PromotionBusiness()
        {
            _promotionData = new PromotionData();
        }

        public string PromoteEmployee(PromotionTransfer promotion)
        {
            var employee = _promotionData.GetEmployeeById(promotion.EmployeeId);

            if (employee == null)
            {
                return "Nhân viên không tồn tại.";
            }

            // Kiểm tra nếu vị trí là Manager
            if (employee.Position.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                return "Không thể thăng cấp cho nhân viên có vị trí là Manager.";
            }
            // Kiểm tra OldPosition khớp với vị trí hiện tại
            if (!employee.Position.Equals(promotion.OldPosition, StringComparison.OrdinalIgnoreCase))
            {
                return "Vị trí cũ không khớp với dữ liệu hiện tại.";
            }

            // Cập nhật vị trí mới
            if (_promotionData.UpdateEmployeePosition(promotion.EmployeeId, promotion.NewPosition))
            {
                // Lưu thông tin thăng chức
                _promotionData.InsertPromotionRecord(promotion);
                return "Cập nhật vị trí thành công!";
            }
            return "Cập nhật vị trí thất bại.";
        }
        public List<PromotionTransfer> GetPromotions()
        {
            return _promotionData.GetPromotions();
        }
    }
}
