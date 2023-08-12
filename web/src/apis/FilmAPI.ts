import { api } from "./configs/axiosConfigs"
import { defineCancelApiObject } from "./configs/axiosUtils"

export const FilmAPI = {
    getFilmWorldMovies: async function (cancel = false) {
        const response = await api.request({
            url: "api/FilmWorld/All",
            method: "GET",
            signal: cancel ? cancelApiObject[this.getFilmWorldMovies.name].handleRequestCancellation().signal : undefined,
          })

          return response.data;
    },

    getFilmWorldMovieDetails: async function (id : string, cancel = false) {
        const response = await api.request({
            url: "api/FilmWorld/Id?id="+id,
            method: "GET",
            signal: cancel ? cancelApiObject[this.getFilmWorldMovieDetails.name].handleRequestCancellation().signal : undefined,
          })

          return response.data;
    },

}

const cancelApiObject = defineCancelApiObject(FilmAPI)