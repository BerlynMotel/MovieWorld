import axios, { AxiosError, AxiosResponse } from "axios"

export const api = axios.create({
  //withCredentials: true,
  baseURL: import.meta.env.VITE_APIBaseUrl,
})

// defining a custom error handler for all APIs
const errorHandler = (error : any) => {
  const err = error as AxiosError
  const statusCode = err.code

  // logging only errors that are not 401
  if (statusCode) {
    console.error(error)
  }

  return Promise.reject(error)
}

// registering the custom error handler to the
// "api" axios instance
api.interceptors.response.use(undefined, (error) => {
  return errorHandler(error)
})
