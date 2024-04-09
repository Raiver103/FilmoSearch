import React, { FC, ReactElement, useRef } from 'react';
import { AddFilmToActorDto, DeleteFilmFromActorDto, Client } from '../api/api';
import { Button, FormControl } from 'react-bootstrap'; 

const apiClient = new Client('https://localhost:44364');

async function addFilmToActor(actorFilm: AddFilmToActorDto) {
    
    await apiClient.add('1.0', actorFilm);
    console.log('ActorFilm is created.');  
      
}  
async function deleteFilmFromActor(actorFilm: DeleteFilmFromActorDto) {
    
    await apiClient.delete2('1.0', actorFilm);
    console.log('ActorFilm is deleted.'); 
}  

const ActorFilmList: FC<{}> = (): ReactElement => { 
    let actorFirstName = useRef<HTMLInputElement>(null);
    let actorLastName = useRef<HTMLInputElement>(null);
    let filmTitle = useRef<HTMLInputElement>(null);
   
    return (
        <div className='block'>
            <div className="title">
                Add film to actor 
            </div>
            <div>
                Actor first name: <FormControl ref={actorFirstName}/>
                Actor last name: <FormControl ref={actorLastName}/> 
                Film title: <FormControl ref={filmTitle}/> 
            </div> 
            <Button className="buttonClass" onClick={() => addFilmToActor({actorFirstName: actorFirstName.current?.value, 
                actorLastName: actorLastName.current?.value,
                filmTitle: filmTitle.current?.value})}>
                Add Film To Actor
            </Button>
            <Button className="buttonClass" onClick={() => deleteFilmFromActor({actorFirstName: actorFirstName.current?.value, 
                actorLastName: actorLastName.current?.value,
                filmTitle: filmTitle.current?.value})}>
                Delete Film From Actor
            </Button>
        </div>
    ); 
};

export default ActorFilmList;