import React, {useEffect, useState} from 'react';
import Movies from "src/components/sections/Movies";
import MovieDetails from "src/components/sections/MovieDetails";
import { MovieType } from 'src/utils/enums/MovieType';

const MainPageLayout = () => {
    const [showList, setShowList] = useState(true);
    const [selectedMovie, setSelectedMovie] = useState("");
    const [selectedMovieType, setSelectedMovieType] = useState<MovieType>();

    const onShowList = (val : boolean) => setShowList(val);

    const onSelectedMovie = (val : string) => setSelectedMovie(val);

    const onSetSelectedMovieType = (val : MovieType) => setSelectedMovieType(val);

    return (
        <div className="movie-container">
            {showList && <Movies onShowList={onShowList} onSelectedMovie={onSelectedMovie} onSetSelectedMovieType={onSetSelectedMovieType}/>}
            {!showList && <MovieDetails onShowList={onShowList} movieId={selectedMovie} movieType={selectedMovieType}/>}
        </div>
     );
   };
   
   export default MainPageLayout;