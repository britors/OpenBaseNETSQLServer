using ProjectTemplate.Infra.Resilience.Http.Policies;

namespace ProjectTemplate.Infra.Resilience.Http.Extensions;

public static class HttpClientResilienceExtension
{
    public static async Task<HttpResponseMessage> PostWithRetryAsync(
        this HttpClient httpClient,
        string requestUri,
        HttpContent content,
        CancellationToken cancellationToken)
    {
        return await HttpClientPolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            return await httpClient.PostAsync(requestUri, content, cancellationToken);
        });
    }

    public static async Task<HttpResponseMessage> GetWithRetryAsync(
                   this HttpClient httpClient,
                    string requestUri,
                    CancellationToken cancellationToken)
    {
        return await HttpClientPolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            return await httpClient.GetAsync(requestUri, cancellationToken);
        });
    }

    public static async Task<HttpResponseMessage> PutWithRetryAsync(
                                this HttpClient httpClient,
                                string requestUri,
                                HttpContent content,
                                CancellationToken cancellationToken)
    {
        return await HttpClientPolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            return await httpClient.PutAsync(requestUri, content, cancellationToken);
        });
    }

    public static Task<HttpResponseMessage> DeleteWithRetryAsync(
                                            this HttpClient httpClient,
                                            string requestUri,
                                            CancellationToken cancellationToken)
    {
        return HttpClientPolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            return await httpClient.DeleteAsync(requestUri, cancellationToken);
        });
    }

    public static async Task<HttpResponseMessage> PatchWithRetryAsync(
                                                    this HttpClient httpClient,
                                                    string requestUri,
                                                    HttpContent content,
                                                    CancellationToken cancellationToken)
    {
        return await HttpClientPolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = content
            };

            return await httpClient.SendAsync(request, cancellationToken);
        });
    }
}