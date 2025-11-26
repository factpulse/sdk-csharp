# FactPulse.SDK.Api.SantApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**HealthcheckHealthcheckGet**](SantApi.md#healthcheckhealthcheckget) | **GET** /healthcheck | Endpoint de healthcheck pour Docker |
| [**RacineGet**](SantApi.md#racineget) | **GET** / | Vérifier l&#39;état de l&#39;API |

<a id="healthcheckhealthcheckget"></a>
# **HealthcheckHealthcheckGet**
> Object HealthcheckHealthcheckGet ()

Endpoint de healthcheck pour Docker

Endpoint de healthcheck pour Docker et les load balancers.  Utile pour : - Docker healthcheck - Kubernetes liveness/readiness probes - Load balancers (Nginx, HAProxy) - Monitoring de disponibilité - Déploiement zero downtime  Retourne un code 200 si l'API est opérationnelle.


### Parameters
This endpoint does not need any parameter.
### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | L&#39;API est en bonne santé |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="racineget"></a>
# **RacineGet**
> Object RacineGet ()

Vérifier l'état de l'API

Endpoint de health check pour vérifier que l'API répond.  Utile pour : - Monitoring de disponibilité - Tests d'intégration - Load balancers


### Parameters
This endpoint does not need any parameter.
### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | L&#39;API est opérationnelle |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

