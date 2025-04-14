using AdminNotificator.Core.Domain;

namespace AdminNotificator.Application.Models.UserProfile;

public class UserProfileAdd
{
    public string Id { get; private set; }

    /// <summary>
    ///     Логин в домене
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    ///     Уникальный ИД в домене
    /// </summary>
    public string Sid { get; private set; }

    /// <summary>
    ///     Имя
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    ///     Фамилия
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    ///     Отчество
    /// </summary>
    public string Patronymic { get; set; }

    /// <summary>
    ///     Электронная почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Дата найма
    /// </summary>
    public DateTime? Seniority { get; set; }

    /// <summary>
    ///     Кол-во дней стажа на момент остановки
    /// </summary>
    public int? SuspendedSeniorityDays { get; set; }

    /// <summary>
    ///     Отделения где работает пользователь
    /// </summary>
    public UserDepartment[] DepartmentItems { get; set; }

    /// <summary>
    ///     Коллекция организаций, в которых работает пользователь
    /// </summary>
    public UserPosition[] UserPositions { get; set; }

    /// <summary>
    ///     Время последней синхронизации (обновления) профиля
    /// </summary>
    public DateTime SyncDate { get; set; }

    /// <summary>
    ///     Идентификаторы подразделений с родительскими
    /// </summary>
    public int[] DepartmentIds { get; set; }

    /// <summary>
    /// Статус пользователя
    /// </summary>
    public UserStatus UserStatus { get; set; }

    /// <summary>
    ///     Стаж
    /// </summary>
    public int? ExperienceDays => SuspendedSeniorityDays ??
                                  (Seniority.HasValue ? (int) (DateTime.UtcNow - Seniority.Value).TotalDays : null);

    /// <summary>
    /// Офис пользователя
    /// </summary>
    public UserOffice UserOffice { get; set; }

    /// <summary>
    /// Пол пользователя
    /// </summary>
    public UserGender UserGender { get; set; }

    /// <summary>
    /// Дата декрета
    /// </summary>
    public DateTime? MaternityLeaveDate { get; set; }
}