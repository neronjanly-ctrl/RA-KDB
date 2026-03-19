using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;

namespace CommonTools;

[Obsolete("WebClientExtensions is obsolete. Use HttpClientExtensions instead.")]
public static class WebClientExtensions
{
    /// <summary>
    ///     Downloads the resource as a <see cref="byte"/> array from the URI specified.
    /// </summary>
    /// <param name="address">The URI from which to download data.</param>
    /// <returns>A <see cref="byte"/> array containing the downloaded resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading data.
    /// </exception>
    /// <exception cref="System.NotSupportedException">The method has been called simultaneously on multiple threads.</exception>
    public static byte[] DownloadData(this string address)
    {
        using WebClient wc = new();
        return wc.DownloadData(address);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="byte"/> array from the URI specified.
    /// </summary>
    /// <param name="address">The URI represented by the <see cref="System.Uri"/> object, from which to download data.</param>
    /// <returns>A <see cref="byte"/> array containing the downloaded resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    public static byte[] DownloadData(this Uri address)
    {
        using WebClient wc = new();
        return wc.DownloadData(address);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="byte"/> array from the URI specified as an asynchronous
    ///     operation.
    /// </summary>
    /// <param name="address">A <see cref="System.Uri"/> containing the URI to download.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static void DownloadDataAsync(this Uri address)
    {
        using WebClient wc = new();
        wc.DownloadDataAsync(address);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="byte"/> array from the URI specified as an asynchronous
    ///     operation.
    /// </summary>
    /// <param name="address">A <see cref="System.Uri"/> containing the URI to download.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static void DownloadDataAsync(this Uri address, object userToken)
    {
        using WebClient wc = new();
        wc.DownloadDataAsync(address, userToken);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="byte"/> array from the URI specified as an asynchronous
    ///     operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the downloaded resource.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static Task<byte[]> DownloadDataTaskAsync(this string address)
    {
        using WebClient wc = new();
        return wc.DownloadDataTaskAsync(address);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="byte"/> array from the URI specified as an asynchronous
    ///     operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the downloaded resource.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static Task<byte[]> DownloadDataTaskAsync(this Uri address)
    {
        using WebClient wc = new();
        return wc.DownloadDataTaskAsync(address);
    }

    /// <summary>
    ///     Downloads the resource with the specified URI to a local file.
    /// </summary>
    /// <param name="address">The URI from which to download data.</param>
    /// <param name="fileName">The name of the local file that is to receive the data.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- filename is null or <see cref="string"/>.Empty. -or- The file does not exist. -or-
    /// </exception>
    ///     An error occurred while downloading data.
    /// <exception cref="System.NotSupportedException">The method has been called simultaneously on multiple threads.</exception>
    public static void DownloadFile(this string address, string fileName)
    {
        using WebClient wc = new();
        wc.DownloadFile(address, fileName);
    }

    /// <summary>
    ///     Downloads the resource with the specified URI to a local file.
    /// </summary>
    /// <param name="address">The URI specified as a <see cref="string"/>, from which to download data.</param>
    /// <param name="fileName">The name of the local file that is to receive the data.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- filename is null or <see cref="string"/>.Empty. -or- The file does not exist. -or-
    /// </exception>
    ///     An error occurred while downloading data.
    /// <exception cref="System.NotSupportedException">The method has been called simultaneously on multiple threads.</exception>
    public static void DownloadFile(this Uri address, string fileName)
    {
        using WebClient wc = new();
        wc.DownloadFile(address, fileName);
    }

    /// <summary>
    ///     Downloads, to a local file, the resource with the specified URI. This method
    ///     does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <param name="fileName">The name of the file to be placed on the local computer.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">The local file specified by fileName is in use by another thread.</exception>
    public static void DownloadFileAsync(this Uri address, string fileName)
    {
        using WebClient wc = new();
        wc.DownloadFileAsync(address, fileName);
    }

    /// <summary>
    ///     Downloads, to a local file, the resource with the specified URI. This method
    ///     does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <param name="fileName">The name of the file to be placed on the local computer.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">The local file specified by fileName is in use by another thread.</exception>
    public static void DownloadFileAsync(this Uri address, string fileName, object userToken)
    {
        using WebClient wc = new();
        wc.DownloadFileAsync(address, fileName, userToken);
    }

    /// <summary>
    ///     Downloads the specified resource to a local file as an asynchronous operation
    ///     using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <param name="fileName">The name of the file to be placed on the local computer.</param>
    /// <returns>
    ///     Returns System.Threading.Tasks.Task. The task object representing the asynchronous
    ///     operation.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">The local file specified by fileName is in use by another thread.</exception>
    public static Task DownloadFileTaskAsync(this Uri address, string fileName)
    {
        using WebClient wc = new();
        return wc.DownloadFileTaskAsync(address, fileName);
    }

    /// <summary>
    ///     Downloads the specified resource to a local file as an asynchronous operation
    ///     using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <param name="fileName">The name of the file to be placed on the local computer.</param>
    /// <returns>
    ///     Returns System.Threading.Tasks.Task. The task object representing the asynchronous
    ///     operation.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">The local file specified by fileName is in use by another thread.</exception>
    public static Task DownloadFileTaskAsync(this string address, string fileName)
    {
        using WebClient wc = new();
        return wc.DownloadFileTaskAsync(address, fileName);
    }

    /// <summary>
    ///     Downloads the requested resource as a <see cref="string"/>. The resource to download
    ///     is specified as a <see cref="System.Uri"/>.
    /// </summary>
    /// <param name="address">A <see cref="System.Uri"/> object containing the URI to download.</param>
    /// <returns>A <see cref="string"/> containing the requested resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    /// <exception cref="System.NotSupportedException">The method has been called simultaneously on multiple threads.</exception>
    public static string DownloadString(this string address)
    {
        using WebClient wc = new();
        return wc.DownloadString(address);
    }

    /// <summary>
    ///     Downloads the requested resource as a <see cref="string"/>. The resource to download
    ///     is specified as a <see cref="string"/> containing the URI.
    /// </summary>
    /// <param name="address">A <see cref="string"/> containing the URI to download.</param>
    /// <returns>A <see cref="string"/> containing the requested resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    /// <exception cref="System.NotSupportedException">The method has been called simultaneously on multiple threads.</exception>
    public static string DownloadString(this Uri address)
    {
        using WebClient wc = new();
        return wc.DownloadString(address);
    }

    /// <summary>
    ///     Downloads the resource specified as a <see cref="System.Uri"/>. This method does not block
    ///     the calling thread.
    /// </summary>
    /// <param name="address">A <see cref="System.Uri"/> containing the URI to download.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static void DownloadStringAsync(this Uri address)
    {
        using WebClient wc = new();
        wc.DownloadStringAsync(address);
    }

    /// <summary>
    ///     Downloads the specified string to the specified resource. This method does not
    ///     block the calling thread.
    /// </summary>
    /// <param name="address">A <see cref="System.Uri"/> containing the URI to download.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static void DownloadStringAsync(this Uri address, object userToken)
    {
        using WebClient wc = new();
        wc.DownloadStringAsync(address, userToken);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="string"/> from the URI specified as an asynchronous
    ///     operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the downloaded resource.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static Task<string> DownloadStringTaskAsync(this string address)
    {
        using WebClient wc = new();
        return wc.DownloadStringTaskAsync(address);
    }

    /// <summary>
    ///     Downloads the resource as a <see cref="string"/> from the URI specified as an asynchronous
    ///     operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to download.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the downloaded resource.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while downloading the resource.
    /// </exception>
    public static Task<string> DownloadStringTaskAsync(this Uri address)
    {
        using WebClient wc = new();
        return wc.DownloadStringTaskAsync(address);
    }
    /// <summary>
    ///     Uploads a data buffer to a resource identified by a URI.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- An error occurred while sending the data. -or-
    ///     There was no response from the server hosting the resource.
    /// </exception>
    public static byte[] UploadData(this Uri address, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadData(address, data);
    }

    /// <summary>
    ///     Uploads a data buffer to a resource identified by a URI.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- An error occurred while sending the data. -or-
    ///     There was no response from the server hosting the resource.
    /// </exception>
    public static byte[] UploadData(this string address, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadData(address, data);
    }

    /// <summary>
    ///     Uploads a data buffer to the specified resource, using the specified method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="method">
    ///     The HTTP method used to send the data to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- An error occurred while uploading the data.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static byte[] UploadData(this string address, string method, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadData(address, method, data);
    }

    /// <summary>
    ///     Uploads a data buffer to the specified resource, using the specified method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="method">
    ///     The HTTP method used to send the data to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- An error occurred while uploading the data.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static byte[] UploadData(this Uri address, string method, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadData(address, method, data);
    }

    /// <summary>
    ///     Uploads a data buffer to a resource identified by a URI, using the POST method.
    ///     This method does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static void UploadDataAsync(this Uri address, byte[] data)
    {
        using WebClient wc = new();
        wc.UploadDataAsync(address, data);
    }

    /// <summary>
    ///     Uploads a data buffer to a resource identified by a URI, using the specified
    ///     method and identifying token.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static void UploadDataAsync(this Uri address, string method, byte[] data, object userToken)
    {
        using WebClient wc = new();
        wc.UploadDataAsync(address, method, data, userToken);
    }

    /// <summary>
    ///     Uploads a data buffer to a resource identified by a URI, using the specified
    ///     method. This method does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static void UploadDataAsync(this Uri address, string method, byte[] data)
    {
        using WebClient wc = new();
        wc.UploadDataAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads a data buffer that contains a <see cref="byte"/> array to the URI specified
    ///     as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the data buffer was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static Task<byte[]> UploadDataTaskAsync(this Uri address, string method, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadDataTaskAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads a data buffer that contains a <see cref="byte"/> array to the URI specified
    ///     as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the data buffer was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static Task<byte[]> UploadDataTaskAsync(this Uri address, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadDataTaskAsync(address, data);
    }

    /// <summary>
    ///     Uploads a data buffer that contains a <see cref="byte"/> array to the URI specified
    ///     as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the data buffer was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static Task<byte[]> UploadDataTaskAsync(this string address, string method, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadDataTaskAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads a data buffer that contains a <see cref="byte"/> array to the URI specified
    ///     as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the data buffer was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- An error occurred while opening the stream. -or- There was no response from
    ///     the server hosting the resource.
    /// </exception>
    public static Task<byte[]> UploadDataTaskAsync(this string address, byte[] data)
    {
        using WebClient wc = new();
        return wc.UploadDataTaskAsync(address, data);
    }

    /// <summary>
    ///     Uploads the specified local file to a resource with the specified URI.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For example, ftp://localhost/samplefile.txt.</param>
    /// <param name="fileName">The file to send to the resource. For example, "samplefile.txt".</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- fileName is null, is <see cref="string"/>.Empty, contains invalid characters,
    ///     or does not exist. -or- An error occurred while uploading the file. -or- There
    ///     was no response from the server hosting the resource. -or- The Content-type header
    ///     begins with multipart.
    /// </exception>
    public static byte[] UploadFile(this Uri address, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFile(address, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to the specified resource, using the specified
    ///     method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file.</param>
    /// <param name="method">
    ///     The method used to send the file to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="fileName">The file to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- fileName is null, is <see cref="string"/>.Empty, contains invalid characters,
    ///     or does not exist. -or- An error occurred while uploading the file. -or- There
    ///     was no response from the server hosting the resource. -or- The Content-type header
    ///     begins with multipart.
    /// </exception>
    public static byte[] UploadFile(this Uri address, string method, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFile(address, method, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to a resource with the specified URI.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For example, ftp://localhost/samplefile.txt.</param>
    /// <param name="fileName">The file to send to the resource. For example, "samplefile.txt".</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- fileName is null, is <see cref="string"/>.Empty, contains invalid characters,
    ///     or does not exist. -or- An error occurred while uploading the file. -or- There
    ///     was no response from the server hosting the resource. -or- The Content-type header
    ///     begins with multipart.
    /// </exception>
    public static byte[] UploadFile(this string address, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFile(address, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to the specified resource, using the specified
    ///     method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file.</param>
    /// <param name="method">
    ///     The method used to send the file to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="fileName">The file to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- fileName is null, is <see cref="string"/>.Empty, contains invalid characters,
    ///     or does not exist. -or- An error occurred while uploading the file. -or- There
    ///     was no response from the server hosting the resource. -or- The Content-type header
    ///     begins with multipart.
    /// </exception>
    public static byte[] UploadFile(this string address, string method, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFile(address, method, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to the specified resource, using the POST method.
    ///     This method does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="fileName">The file to send to the resource.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static void UploadFileAsync(this Uri address, string method, string fileName, object userToken)
    {
        using WebClient wc = new();
        wc.UploadFileAsync(address, method, fileName, userToken);
    }

    /// <summary>
    ///     Uploads the specified local file to the specified resource, using the POST method.
    ///     This method does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="fileName">The file to send to the resource.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static void UploadFileAsync(this Uri address, string method, string fileName)
    {
        using WebClient wc = new();
        wc.UploadFileAsync(address, method, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to the specified resource, using the POST method.
    ///     This method does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="fileName">The file to send to the resource.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static void UploadFileAsync(this Uri address, string fileName)
    {
        using WebClient wc = new();
        wc.UploadFileAsync(address, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to a resource as an asynchronous operation using
    ///     a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="fileName">The local file to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the file was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static Task<byte[]> UploadFileTaskAsync(this string address, string method, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFileTaskAsync(address, method, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to a resource as an asynchronous operation using
    ///     a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The method used to send the data to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="fileName">The local file to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the file was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static Task<byte[]> UploadFileTaskAsync(this Uri address, string method, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFileTaskAsync(address, method, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to a resource as an asynchronous operation using
    ///     a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="fileName">The local file to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the file was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static Task<byte[]> UploadFileTaskAsync(this string address, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFileTaskAsync(address, fileName);
    }

    /// <summary>
    ///     Uploads the specified local file to a resource as an asynchronous operation using
    ///     a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the file. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="fileName">The local file to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the body of the response received from
    ///     the resource when the file was uploaded.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The fileName parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- fileName is null, is <see cref="string"/>.Empty, contains invalid character, or
    /// </exception>
    ///     the specified path to the file does not exist. -or- An error occurred while opening
    ///     the stream. -or- There was no response from the server hosting the resource.
    ///     -or- The Content-type header begins with multipart.
    /// </exception>
    public static Task<byte[]> UploadFileTaskAsync(this Uri address, string fileName)
    {
        using WebClient wc = new();
        return wc.UploadFileTaskAsync(address, fileName);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource, using the POST method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For Http resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>A <see cref="string"/> containing the response sent by the server.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static string UploadString(this string address, string data)
    {
        using WebClient wc = new();
        return wc.UploadString(address, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource, using the specified method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. This URI must identify a resource</param>
    ///     that can accept a request sent with the method method.
    /// <param name="method">
    ///     The HTTP method used to send the string to the resource. If null, the default
    ///     is POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>A <see cref="string"/> containing the response sent by the server.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource. -or- method
    ///     cannot be used to send content.
    /// </exception>
    public static string UploadString(this string address, string method, string data)
    {
        using WebClient wc = new();
        return wc.UploadString(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource, using the specified method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. This URI must identify a resource</param>
    ///     that can accept a request sent with the method method.
    /// <param name="method">
    ///     The HTTP method used to send the string to the resource. If null, the default
    ///     is POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>A <see cref="string"/> containing the response sent by the server.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource. -or- method
    ///     cannot be used to send content.
    /// </exception>
    public static string UploadString(this Uri address, string method, string data)
    {
        using WebClient wc = new();
        return wc.UploadString(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource, using the POST method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For Http resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>A <see cref="string"/> containing the response sent by the server.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static string UploadString(this Uri address, string data)
    {
        using WebClient wc = new();
        return wc.UploadString(address, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource. This method does not
    ///     block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The HTTP method used to send the file to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The string to be uploaded.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- method cannot be used to send content. -or- There was no response from the
    ///     server hosting the resource.
    /// </exception>
    public static void UploadStringAsync(this Uri address, string method, string data, object userToken)
    {
        using WebClient wc = new();
        wc.UploadStringAsync(address, method, data, userToken);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource. This method does not
    ///     block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The HTTP method used to send the file to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The string to be uploaded.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- method cannot be used to send content. -or- There was no response from the
    ///     server hosting the resource.
    /// </exception>
    public static void UploadStringAsync(this Uri address, string method, string data)
    {
        using WebClient wc = new();
        wc.UploadStringAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource. This method does not
    ///     block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="data">The string to be uploaded.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static void UploadStringAsync(this Uri address, string data)
    {
        using WebClient wc = new();
        wc.UploadStringAsync(address, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource as an asynchronous operation
    ///     using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="string"/> containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static Task<string> UploadStringTaskAsync(this Uri address, string data)
    {
        using WebClient wc = new();
        return wc.UploadStringTaskAsync(address, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource as an asynchronous operation
    ///     using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The HTTP method used to send the file to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="string"/> containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- method cannot be used to send content. -or- There was no response from the
    ///     server hosting the resource.
    /// </exception>
    public static Task<string> UploadStringTaskAsync(this Uri address, string method, string data)
    {
        using WebClient wc = new();
        return wc.UploadStringTaskAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource as an asynchronous operation
    ///     using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="string"/> containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static Task<string> UploadStringTaskAsync(this string address, string data)
    {
        using WebClient wc = new();
        return wc.UploadStringTaskAsync(address, data);
    }

    /// <summary>
    ///     Uploads the specified string to the specified resource as an asynchronous operation
    ///     using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the string. For HTTP resources, this URI must</param>
    ///     identify a resource that can accept a request sent with the POST method, such
    ///     as a script or ASP page.
    /// <param name="method">
    ///     The HTTP method used to send the file to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The string to be uploaded.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="string"/> containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- method cannot be used to send content. -or- There was no response from the
    ///     server hosting the resource.
    /// </exception>
    public static Task<string> UploadStringTaskAsync(this string address, string method, string data)
    {
        using WebClient wc = new();
        return wc.UploadStringTaskAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- There was no response from the server hosting
    ///     the resource. -or- An error occurred while opening the stream. -or- The Content-type
    ///     header is not null or "application/x-www-form-urlencoded".
    /// </exception>
    public static byte[] UploadValues(this string address, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValues(address, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- There was no response from the server hosting
    ///     the resource. -or- An error occurred while opening the stream. -or- The Content-type
    ///     header is not null or "application/x-www-form-urlencoded".
    /// </exception>
    public static byte[] UploadValues(this Uri address, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValues(address, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI, using the specified method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="method">
    ///     The HTTP method used to send the file to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- An error occurred while opening the stream.
    ///     -or- There was no response from the server hosting the resource. -or- The Content-type
    ///     header value is not null and is not application/x-www-form-urlencoded.
    /// </exception>
    public static byte[] UploadValues(this Uri address, string method, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValues(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI, using the specified method.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="method">
    ///     The HTTP method used to send the file to the resource. If null, the default is
    ///     POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>A <see cref="byte"/> array containing the body of the response from the resource.</returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- data is null. -or- An error occurred while opening the stream.
    ///     -or- There was no response from the server hosting the resource. -or- The Content-type
    ///     header value is not null and is not application/x-www-form-urlencoded.
    /// </exception>
    public static byte[] UploadValues(this string address, string method, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValues(address, method, data);
    }

    /// <summary>
    ///     Uploads the data in the specified name/value collection to the resource identified
    ///     by the specified URI. This method does not block the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection. This URI must identify a resource</param>
    ///     that can accept a request sent with the default method.
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource.
    /// </exception>
    public static void UploadValuesAsync(this Uri address, NameValueCollection data)
    {
        using WebClient wc = new();
        wc.UploadValuesAsync(address, data);
    }

    /// <summary>
    ///     Uploads the data in the specified name/value collection to the resource identified
    ///     by the specified URI, using the specified method. This method does not block
    ///     the calling thread.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection. This URI must identify a resource</param>
    ///     that can accept a request sent with the method method.
    /// <param name="method">
    ///     The method used to send the string to the resource. If null, the default is POST
    ///     for http and STOR for ftp.
    /// </param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource. -or- method
    ///     cannot be used to send content.
    /// </exception>
    public static void UploadValuesAsync(this Uri address, string method, NameValueCollection data)
    {
        using WebClient wc = new();
        wc.UploadValuesAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads the data in the specified name/value collection to the resource identified
    ///     by the specified URI, using the specified method. This method does not block
    ///     the calling thread, and allows the caller to pass an object to the method that
    ///     is invoked when the operation completes.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection. This URI must identify a resource</param>
    ///     that can accept a request sent with the method method.
    /// <param name="method">
    ///     The HTTP method used to send the string to the resource. If null, the default
    ///     is POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <param name="userToken">
    ///     A user-defined object that is passed to the method invoked when the asynchronous
    ///     operation completes.
    /// </param>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">
    ///     The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/> and address is invalid.
    ///     -or- There was no response from the server hosting the resource. -or- method
    ///     cannot be used to send content.
    /// </exception>
    public static void UploadValuesAsync(this Uri address, string method, NameValueCollection data, object userToken)
    {
        using WebClient wc = new();
        wc.UploadValuesAsync(address, method, data, userToken);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="method">
    ///     The HTTP method used to send the collection to the resource. If null, the default
    ///     is POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- method cannot be used to send content. -or- There was no response
    ///     from the server hosting the resource. -or- An error occurred while opening the
    ///     stream. -or- The Content-type header is not null or "application/x-www-form-urlencoded".
    /// </exception>
    public static Task<byte[]> UploadValuesTaskAsync(this Uri address, string method, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValuesTaskAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="method">
    ///     The HTTP method used to send the collection to the resource. If null, the default
    ///     is POST for http and STOR for ftp.
    /// </param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- method cannot be used to send content. -or- There was no response
    ///     from the server hosting the resource. -or- An error occurred while opening the
    ///     stream. -or- The Content-type header is not null or "application/x-www-form-urlencoded".
    /// </exception>
    public static Task<byte[]> UploadValuesTaskAsync(this string address, string method, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValuesTaskAsync(address, method, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the response sent by the server.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- There was no response from the server hosting the resource. -or-
    ///     An error occurred while opening the stream. -or- The Content-type header is not
    ///     null or "application/x-www-form-urlencoded".
    /// </exception>
    public static Task<byte[]> UploadValuesTaskAsync(this string address, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValuesTaskAsync(address, data);
    }

    /// <summary>
    ///     Uploads the specified name/value collection to the resource identified by the
    ///     specified URI as an asynchronous operation using a task object.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the collection.</param>
    /// <param name="data">The <see cref="System.Collections.Specialized.NameValueCollection"/> to send to the resource.</param>
    /// <returns>
    ///     Returns <see cref="System.Threading.Tasks.Task"/>. The task object representing the asynchronous
    ///     operation. The <see cref="System.Threading.Tasks.Task{Result}"/> property on the task object
    ///     returns a <see cref="byte"/> array containing the response sent by the server.
    /// <exception cref="System.ArgumentNullException">The address parameter is null. -or- The data parameter is null.</exception>
    /// <exception cref="System.Net.WebException">The URI formed by combining <see cref="System.Net.WebClient.BaseAddress"/>, and address is
    ///     invalid. -or- An error occurred while opening the stream. -or- There was no response
    ///     from the server hosting the resource. -or- The Content-type header value is not
    ///     null and is not application/x-www-form-urlencoded.
    /// </exception>
    public static Task<byte[]> UploadValuesTaskAsync(this Uri address, NameValueCollection data)
    {
        using WebClient wc = new();
        return wc.UploadValuesTaskAsync(address, data);
    }
}
