import { MovieType } from "../enums/MovieType"

export interface Movie{
    Title : string
    Year : number
    ID : string
    Type : string
    Poster : string
    Origin : MovieType
}