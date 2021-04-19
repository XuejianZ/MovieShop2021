import { CastCard } from './cast-card';

export interface MovieDetails {
        id: number;
        title: string;
        overview: string;
        tagline?: any;
        budget: number;
        revenue: number;
        imdbUrl?: any;
        tmdbUrl?: any;
        posterUrl: string;
        backdropUrl?: any;
        originalLanguage?: any;
        releaseDate: Date;
        runTime: number;
        price: number;
        createdDate: Date;
        updatedDate: Date;
        updatedBy?: any;
        createdBy?: any;
        rating: number;
        casts: CastCard[];
        review?: any;
        genre: Genre[];
    }
/*
    export interface Cast {
        id: number;
        name: string;
        gender?: any;
        tmdbUrl?: any;
        profilePath: string;
        movieId: number;
        castId: number;
        character: string;
        cast?: any;
    }
*/  
     export interface Genre {
        id: number;
        name: string;
     }
    
     
    






