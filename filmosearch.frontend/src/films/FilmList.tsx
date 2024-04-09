import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateFilmDto, Client, FilmLookupDto, UpdateFilmDto, FilmDetailsVm } from '../api/api';
import { Button, FormControl } from 'react-bootstrap';

const apiClient = new Client('https://localhost:44364');
 
const FilmList: FC<{}> = (): ReactElement => {
    let filmTitle = useRef<HTMLInputElement>(null);
    let filmId = useRef<HTMLInputElement>(null);
    const [films, setFilms] = useState<FilmLookupDto[] | undefined>(undefined);
    const [filmDetails, setFilmDetails] = useState<FilmDetailsVm | undefined>(undefined);

    async function createFilm(film: CreateFilmDto) {
        await apiClient.create2('1.0', film);
        console.log('Film is created.');
        setTimeout(getFilms, 100);
    }

    async function updateFilm(film: UpdateFilmDto) {
        await apiClient.update2('1.0', film);
        console.log('Film is updated.');
        setTimeout(getFilms, 100);
    }

    async function deleteFilm(filmId: number) {
        await apiClient.delete3(filmId, "1.0");
        console.log('Film is deleted.');
        setTimeout(getFilms, 100);
    }

    async function getFilms() {
        const filmListVm = await apiClient.getAll2('1.0');
        setFilms(filmListVm.films);
        
    }
    async function getFilm(id: number) {
        const filmDetailsVm = await apiClient.get2(id, '1.0');  
        setFilmDetails(filmDetailsVm);
    }

    useEffect(() => {
        setTimeout(getFilms, 100);
    }, []);
 
    return (
        <div className='block'>
            <div className="title">
                Films
            </div>
            
            <div>
                Film title: <FormControl ref={filmTitle} /> 
                Film id(for update): <FormControl ref={filmId} /> 
            </div>
            <section>
                {films?.map((film ) => (
                    <div key={film.id} className="item">
                        {film.title}    
                        <div className="btns"> 
                            <Button className="buttonClass" onClick={() => deleteFilm(film.id ?? 0 )}>Delete</Button> 
                            <Button className="buttonClass" onClick={() => getFilm(film.id ?? 0)}>View Details</Button>
                        </div>
                    </div>  
                ))}
            </section> 
            <div className="details">
                {filmDetails && (
                    <div>
                        <h2> {filmDetails.title}</h2>
                        <p>Id: {filmDetails.id}</p> 
                        <p>Actors:</p>
                        {filmDetails.actors && filmDetails.actors.map((actor, index) => (
                            <div key={index}>
                                <p>{actor.firstName} {actor.lastName}</p> 
                            </div>
                        ))}
                    </div>
                )}
            </div>
            <Button className="buttonClass" onClick={() => createFilm({title: filmTitle.current?.value})}>
                Add Film
            </Button>
            <Button className="buttonClass" onClick={() => updateFilm({title: filmTitle.current?.value, id:parseInt(filmId.current?.value ?? '')})}>
                Update Film
            </Button>
        </div>
    );
};


export default FilmList;