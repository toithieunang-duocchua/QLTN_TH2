using System;
using System.Timers;
using QLTN.Database;

namespace QLTN.Services
{
    public sealed class ContractMonitorService : IDisposable
    {
        private Timer timer;

        public void Start()
        {
            if (timer != null)
            {
                return;
            }

            timer = new Timer(3600000); // 1 gio
            timer.AutoReset = true;
            timer.Elapsed += CheckExpiredContracts;
            timer.Start();
        }

        private void CheckExpiredContracts(object sender, ElapsedEventArgs e)
        {
            const string query = @"
UPDATE hopdong
SET trangThai = N'Het han',
    ngayCapNhat = GETDATE()
WHERE trangThai = N'Dang hieu luc'
  AND ngayKetThuc < GETDATE();

UPDATE phong
SET trangThai = N'Trong',
    ngayCapNhat = GETDATE()
FROM phong p
INNER JOIN hopdong hd ON p.id = hd.idPhong
WHERE hd.trangThai = N'Het han'
  AND p.trangThai = N'Dang thue';";

            try
            {
                DatabaseConnection.Instance.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                AuditLogger.LogError($"Contract monitor failed: {ex.Message}");
            }
        }

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Elapsed -= CheckExpiredContracts;
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
    }
}
