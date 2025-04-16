import axios from "axios"

export default function useApi() {
    const httpClient = axios.create({
        baseURL: "",
        adapter: "http",
        withCredentials: true,
        timeout: 3000000,
    });

    httpClient.interceptors.response.use(
        (response) => response,
        (error) => {
            if ((error.status === 401 | error.status === 403)) {

            }
        }
    )

    return httpClient
}



