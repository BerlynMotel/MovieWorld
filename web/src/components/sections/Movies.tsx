import React, {useEffect, useState} from 'react';
import { CinemaAPI } from "apis/CinemaAPI";
import { FilmAPI } from "apis/FilmAPI";
import { MovieList } from 'src/utils/models/MovieList';
import { MovieType } from 'src/utils/enums/MovieType';
import { Movie } from 'src/utils/models/Movie';

interface DetailsProps {
    onShowList : (e : any) => void;
    onSelectedMovie : (e : any) => void;
    onSetSelectedMovieType : (e : any) => void;
}

const Movies =({
    onShowList,
    onSelectedMovie,
    onSetSelectedMovieType
  }: DetailsProps)  => {
    const [isFetchingData, setIsFetchingData] = useState(false);
    const [isFetchingDataSuccessful, setIsFetchingDataSuccessful] = useState(true);
    const [isFetchingCinemaDataSuccessful, setIsFetchingCinemaDataSuccessful] = useState(true);
    const [isFetchingFilmDataSuccessful, setIsFetchingFilmDataSuccessful] = useState(true);
    const [movies, setMovies] = useState<Movie[]>([]);
    const [filmmovies, setFilmMovies] = useState<Movie[]>([]);
    const [cinemamovies, setCinemaMovies] = useState<Movie[]>([]);

    const GetCinemaMovies = () => {
        setIsFetchingData(true);
        CinemaAPI.getCinemaWorldMovies()
        .then(function (response) {
            var result = response as MovieList;
            setCinemaMovies(result.Movies);
        })
        .catch(function (error) {
            setIsFetchingCinemaDataSuccessful(false);
        })
        .finally(() => {
            GetFilmMovies();
        });
    }

    const GetFilmMovies = () => {
        FilmAPI.getFilmWorldMovies()
        .then(function (response) {
            var result = response as MovieList;
            setFilmMovies(result.Movies);
        })
        .catch(function (error) {
            setIsFetchingFilmDataSuccessful(false);
        })
        .finally(() => {
            setIsFetchingData(false);
            setIsFetchingDataSuccessful(isFetchingCinemaDataSuccessful || isFetchingFilmDataSuccessful);

            PopulateMovies();
        });
    }

    const PopulateMovies = () => {
        var c = [...cinemamovies, ...filmmovies];
        c = c.sort((a, b) => (a.Year < b.Year) ? 1 : -1);
        setMovies(c);
    }

    const onMovieClick = (id :string, type :MovieType) => {
        onShowList(false);
        onSelectedMovie(id);
        onSetSelectedMovieType(type);
    }

    useEffect(() => {
        if(movies.length === 0) GetCinemaMovies();
    }, [isFetchingDataSuccessful, movies]);

    return (
        <>
            <div className="row movie-list-page">
                {
                    isFetchingDataSuccessful && !isFetchingData && movies && movies.map((val) => (
                        <div className="col-md-2 movie-tile card" key={val.ID} onClick={() =>onMovieClick(val.ID, val.Origin)}>
                            <img className="card-img-top" src={val.Poster} />
                            <div className="card-body">
                                <h5 className="card-title">{val.Title}</h5>
                                <p className="card-text"><b>Year:</b> {val.Year}</p>
                            </div>
                        </div>
                    ))
                }
            </div>

            {isFetchingData && 
                <div className="d-flex justify-content-center">
                    <div className="spinner-border" role="status">
                    <span className="sr-only">Loading...</span>
                    </div>
                </div>
            }

            {!isFetchingData && !isFetchingDataSuccessful &&
                <div className="alert alert-danger" role="alert">
                    Error fetching movies. Please try again later.
                </div>
            } 
        </>
    );
  };
  
  export default Movies;