import { api } from "./configs/axiosConfigs"
import { defineCancelApiObject } from "./configs/axiosUtils"

export const CinemaAPI = {
    getCinemaWorldMovies: async function (cancel = false) {
        const response = await api.request({
            url: "api/CinemaWorld/All",
            method: "GET",
            signal: cancel ? cancelApiObject[this.getCinemaWorldMovies.name].handleRequestCancellation().signal : undefined,
          })

          return response.data;
    },

    getCinemaWorldMovieDetails: async function (id : string, cancel = false) {
        const response = await api.request({
            url: "api/CinemaWorld/Id?id="+id,
            method: "GET",
            signal: cancel ? cancelApiObject[this.getCinemaWorldMovieDetails.name].handleRequestCancellation().signal : undefined,
          })

          return response.data;
    },
}

const cancelApiObject = defineCancelApiObject(CinemaAPI)