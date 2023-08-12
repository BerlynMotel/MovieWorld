import React, {useEffect, useState} from 'react';
import { CinemaAPI } from "apis/CinemaAPI";
import { FilmAPI } from "apis/FilmAPI";
import { MovieData } from 'src/utils/models/MovieData';
import { MovieType } from 'src/utils/enums/MovieType';

interface DetailsProps {
    onShowList : (e : any) => void;
    movieId : string,
    movieType : MovieType | undefined
}

const MovieDetails =({
    onShowList,
    movieType,
    movieId
  }: DetailsProps)  => {
    const [isFetchingData, setIsFetchingData] = useState(false);
    const [isFetchingDataSuccessful, setIsFetchingDataSuccessful] = useState(true);
    const [movie, setMovie] = useState<MovieData>();

    const GetCinemaMovieDetails = () => {
        CinemaAPI.getCinemaWorldMovieDetails(movieId)
        .then(function (response) {
            var result = response as MovieData;
            setMovie(result);
        })
        .catch(function (error) {
            setIsFetchingDataSuccessful(false);
        })
        .finally(() => {
            setIsFetchingData(false);
        });
    }

    const GetFilmMovieDetails = () => {
        FilmAPI.getFilmWorldMovieDetails(movieId)
        .then(function (response) {
            var result = response as MovieData;
            setMovie(result);
        })
        .catch(function (error) {
            setIsFetchingDataSuccessful(false);
        })
        .finally(() => {
            setIsFetchingData(false);
        });
    }

    const GetMovieDetails = () => {
        setIsFetchingData(true);
        
        if(movieType == MovieType.Cinema) GetCinemaMovieDetails();
        else GetFilmMovieDetails();
    }

    useEffect(() => {
        GetMovieDetails();
    }, [movieId]);
     return (
         <>
            <p className="backlink" onClick={() => onShowList(true)}>Back to Movie List</p><br/>

            {!isFetchingData && isFetchingDataSuccessful && <>
                <div className="card flex-row flex-wrap row">
                    <div className="card-header border-0 col-md-3">
                        <img src={movie?.Poster} alt=""/>
                    </div>
                    <div className="card-block px-2 col-md-9">
                        <h4 className="card-title">{movie?.Title}</h4>
                        <p className="card-text">{movie?.Plot}</p>
                        <p className="card-text"><b>Director:</b> {movie?.Director}</p>
                        <p className="card-text"><b>Writer:</b> {movie?.Writer}</p>
                        <p className="card-text"><b>Actors:</b> {movie?.Actors}</p>
                        <p className="card-text"><b>Year:</b> {movie?.Year}</p>
                        <p className="card-text"><b>Released:</b> {movie?.Released.toDateString()}</p>
                        <p className="card-text"><b>Rated:</b> {movie?.Rated}</p>
                        <p className="card-text"><b>Genre:</b> {movie?.Genre}</p>
                        <p className="card-text"><b>Price:</b> {movie?.Price}</p>
                        <p className="card-text"><b>Runtime:</b> {movie?.Runtime}</p>
                        <p className="card-text"><b>Language:</b> {movie?.Language}</p>
                        <p className="card-text"><b>Country:</b> {movie?.Country}</p>
                    </div>
                    <div className="card-footer w-100 text-muted">
                        <b>Rating:</b> {movie?.Rating} | <b>Metascore:</b> {movie?.Metascore} | <b>Votes:</b> {movie?.Votes}
                    </div>
                </div>
            </>
            }
            {isFetchingData && 
                <div className="d-flex justify-content-center">
                    <div className="spinner-border" role="status">
                    <span className="sr-only">Loading...</span>
                    </div>
                </div>
            }

            {!isFetchingData && !isFetchingDataSuccessful &&
                <div className="alert alert-danger" role="alert">
                    Error fetching movie details. Please try again later.
                </div>
            }   
        </>
     );
   };
   
   export default MovieDetails;