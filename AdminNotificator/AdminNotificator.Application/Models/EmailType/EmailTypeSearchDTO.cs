namespace AdminNotificator.Application.Models.EmailType;

public class EmailTypeSearchDTO
{
    /// <summary>
    /// Количество дней в компании
    /// </summary>
    public int? ExperianceDays { get; set; }

    /// <summary>
    /// Отправлять письма только сотрудникам указанных отделов
    /// </summary>
    public int[]? IntersectDepartmentIds { get; set; }

    /// <summary>
    /// Отправлять письма всем сотркдникам кроме указанных списка отделов
    /// </summary>
    public int[]? ExceptDepartmentIds { get; set; }

    /// <summary>
    /// Отправлять письма только сотрудникам указанных организаций
    /// </summary>
    public string[]? IntersectOrganizationNames { get; set; }

    /// <summary>
    /// Отправлять письма только сотрудникам указанных городов
    /// </summary>
    public string[]? IntersectTowns { get; set; }

    /// <summary>
    /// Не отправлять письма сотрудникам указанных городов
    /// </summary>
    public string[]? ExceptTowns { get; set; }

    /// <summary>
    /// Кол-во дней декретного отпуска, через которое нужно отправить письмо
    /// </summary>
    public int? MaternityDays { get; set; }

    /// <summary>
    /// для какого пола письмо
    /// </summary>
    public string[]? ForGenders { get; set; }

    /// <summary>
    /// Отправлять письма только сотрудникам указанных должностей
    /// </summary>
    public HashSet<string>? IntersectUserPosts { get; set; }

    /// <summary>
    /// Отправлять письма всем сотрудникам кроме указанных должностей
    /// </summary>
    public HashSet<string>? ExceptUserPosts { get; set; }
}