using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using trabajo_de_SF2.Models;

namespace trabajo_de_SF2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        var model = new DashboardModel
        {
            Status = "Operativo",
            LastValidation = "Hace 45s",
            LatencyMs = 124,
            UptimePercent = 100,
            LastSyncTime = "12:45:03 PM",
            CriticalServices = new List<CriticalService>
            {
                new CriticalService { Provider = "AWS CORE SERVICES", ServiceName = "EC2 Instances", Status = "OK", StatusColor = "#10b981", Icon = "✓" },
                new CriticalService { Provider = "AWS CORE SERVICES", ServiceName = "S3 Storage", Status = "OK", StatusColor = "#10b981", Icon = "✓" },
                new CriticalService { Provider = "AWS CORE SERVICES", ServiceName = "Lambda Serverless", Status = "WARNING", StatusColor = "#f59e0b", Icon = "⚠" },
                new CriticalService { Provider = "MICROSOFT AZURE", ServiceName = "Entra ID (Auth)", Status = "OK", StatusColor = "#10b981", Icon = "✓" },
                new CriticalService { Provider = "MICROSOFT AZURE", ServiceName = "SQL Managed Instance", Status = "CRITICAL", StatusColor = "#ef4444", Icon = "✕" },
                new CriticalService { Provider = "MICROSOFT AZURE", ServiceName = "App Services", Status = "OK", StatusColor = "#10b981", Icon = "✓" }
            },
            ApiSyncs = new List<ApiSync>
            {
                new ApiSync { Name = "AWS CloudWatch", Status = "EXITOSO", StatusColor = "#10b981", LastSync = "Hace 2 min", SyncType = "Live Auto-Sync" },
                new ApiSync { Name = "Azure Resource Graph", Status = "DEGRADADO", StatusColor = "#f59e0b", LastSync = "Hace 38 min", SyncType = "Stale. Remotizado" },
                new ApiSync { Name = "M365 Admin Center", Status = "EXITOSO", StatusColor = "#10b981", LastSync = "Hace 12 min", SyncType = "Stale. Conectado" }
            }
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        // Datos de ejemplo para los incidentes
        var incidents = new Dictionary<int, IncidentModel>
        {
            {
                1, new IncidentModel
                {
                    Id = 1,
                    Provider = "Azure",
                    ProviderIcon = "🔵",
                    Title = "Interrupción Crítica de Azure SQL",
                    Severity = "CRÍTICO",
                    SeverityColor = "#ef4444",
                    Duration = "02:14:45",
                    Location = "US Este (Virginia)",
                    RootCauseAnalysis = "La telemetría indica una mala configuración de red en la capa SDN de Azure. Una actualización rutinaria del gestor de tráfico causó un bucle de enrutamiento recursivo, bloqueando las solicitudes a las instancias de SQL.\n\nIngeniería de Azure confirma el problema y aplica una reversión. Monitoreo interno confirma un 100% de pérdida de paquetes.",
                    Timeline = new List<TimelineEvent>
                    {
                        new TimelineEvent { Time = "14:19UTC", Description = "Anomalía detectada" },
                        new TimelineEvent { Time = "14:25UTC", Description = "Localización automatizada" },
                        new TimelineEvent { Time = "14:20UTC", Description = "SRE reconoció: J. Miller" }
                    },
                    ImpactedServices = new List<ServiceImpact>
                    {
                        new ServiceImpact { Severity = "CRÍTICO", ServiceName = "Portal Cliente", SeverityColor = "#ef4444" },
                        new ServiceImpact { Severity = "DEGRADADO", ServiceName = "Pagos", SeverityColor = "#f59e0b" },
                        new ServiceImpact { Severity = "CRÍTICO", ServiceName = "API Móvil Auth", SeverityColor = "#ef4444" }
                    },
                    OfficialLinks = new List<string>
                    {
                        "Azure Status Page",
                        "Support Dashboard",
                        "Incident Report PDF",
                        "Post-Mortem Preliminar"
                    },
                    Responders = new List<Responder>
                    {
                        new Responder { Role = "Equipo DevOps", Name = "", Status = true },
                        new Responder { Role = "SRE De Guardia", Name = "", Status = true },
                        new Responder { Role = "Líderes Producto", Name = "", Status = true }
                    },
                    TechnicalDetails = "incident.me.impala.rt.ai"
                }
            },
            {
                2, new IncidentModel
                {
                    Id = 2,
                    Provider = "AWS",
                    ProviderIcon = "🟠",
                    Title = "Almacenamiento S3 - Disponibilidad Reducida",
                    Severity = "MAYOR",
                    SeverityColor = "#f59e0b",
                    Duration = "00:45:12",
                    Location = "US Este (N. Virginia)",
                    RootCauseAnalysis = "Aumento de tráfico inusual en la región de US Este causó limitación temporal en la tasa de solicitudes.",
                    Timeline = new List<TimelineEvent>
                    {
                        new TimelineEvent { Time = "14:50UTC", Description = "Spike de tráfico detectado" },
                        new TimelineEvent { Time = "14:55UTC", Description = "Escalado automático iniciado" },
                        new TimelineEvent { Time = "15:35UTC", Description = "Situación normalizada" }
                    },
                    ImpactedServices = new List<ServiceImpact>
                    {
                        new ServiceImpact { Severity = "MAYOR", ServiceName = "Almacenamiento S3", SeverityColor = "#f59e0b" }
                    },
                    OfficialLinks = new List<string>
                    {
                        "AWS Status Page",
                        "Support Dashboard"
                    },
                    Responders = new List<Responder>
                    {
                        new Responder { Role = "Equipo DevOps", Name = "", Status = true },
                        new Responder { Role = "SRE De Guardia", Name = "", Status = true }
                    },
                    TechnicalDetails = "s3.operations.tracker.aws"
                }
            },
            {
                3, new IncidentModel
                {
                    Id = 3,
                    Provider = "Microsoft 365",
                    ProviderIcon = "🟢",
                    Title = "Exchange Online - Sincronización Lenta",
                    Severity = "MENOR",
                    SeverityColor = "#10b981",
                    Duration = "05:22:19",
                    Location = "Global",
                    RootCauseAnalysis = "Inconsistencia temporal en la replicación de datos entre centros de datos.",
                    Timeline = new List<TimelineEvent>
                    {
                        new TimelineEvent { Time = "10:00UTC", Description = "Degradación detectada" },
                        new TimelineEvent { Time = "10:15UTC", Description = "Sincronización de réplicas" },
                        new TimelineEvent { Time = "15:22UTC", Description = "Servicio restaurado" }
                    },
                    ImpactedServices = new List<ServiceImpact>
                    {
                        new ServiceImpact { Severity = "MENOR", ServiceName = "Exchange Online", SeverityColor = "#10b981" }
                    },
                    OfficialLinks = new List<string>
                    {
                        "M365 Status Page"
                    },
                    Responders = new List<Responder>
                    {
                        new Responder { Role = "SRE De Guardia", Name = "", Status = true }
                    },
                    TechnicalDetails = "exchange.sync.m365.status"
                }
            },
            {
                4, new IncidentModel
                {
                    Id = 4,
                    Provider = "Azure",
                    ProviderIcon = "🔵",
                    Title = "Azure AD - Autenticación Intermitente",
                    Severity = "MAYOR",
                    SeverityColor = "#f59e0b",
                    Duration = "00:12:39",
                    Location = "Global",
                    RootCauseAnalysis = "Caché distribuida desincronizada en endpoints de autenticación.",
                    Timeline = new List<TimelineEvent>
                    {
                        new TimelineEvent { Time = "14:45UTC", Description = "Fallos de autenticación reportados" },
                        new TimelineEvent { Time = "14:50UTC", Description = "Invalidación de caché iniciada" },
                        new TimelineEvent { Time = "14:57UTC", Description = "Sistema normalizado" }
                    },
                    ImpactedServices = new List<ServiceImpact>
                    {
                        new ServiceImpact { Severity = "MAYOR", ServiceName = "Autenticación AD", SeverityColor = "#f59e0b" }
                    },
                    OfficialLinks = new List<string>
                    {
                        "Azure Status Page",
                        "Support Dashboard"
                    },
                    Responders = new List<Responder>
                    {
                        new Responder { Role = "Equipo DevOps", Name = "", Status = true },
                        new Responder { Role = "SRE De Guardia", Name = "", Status = true }
                    },
                    TechnicalDetails = "azure.ad.auth.identity"
                }
            }
        };

        if (incidents.ContainsKey(id))
        {
            return View(incidents[id]);
        }

        return NotFound();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
