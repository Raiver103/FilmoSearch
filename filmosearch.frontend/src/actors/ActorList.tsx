import { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateActorDto, Client, ActorLookupDto, UpdateActorDto, ActorDetailsVm } from '../api/api';
import { Button, FormControl } from 'react-bootstrap';

const apiClient = new Client('https://localhost:44364');
 
const ActorList: FC<{}> = (): ReactElement => {
    let textInput1 = useRef<HTMLInputElement>(null);
    let textInput2 = useRef<HTMLInputElement>(null);
    let textInput3 = useRef<HTMLInputElement>(null);
    const [actors, setActors] = useState<ActorLookupDto[] | undefined>(undefined);
    const [actorDetails, setActorDetails] = useState<ActorDetailsVm | undefined>(undefined);

    async function createActor(actor: CreateActorDto) {
        await apiClient.create('1.0', actor);
        console.log('Actor is created.');  
        setTimeout(getActors, 100);
    } 

    async function updateActor(actor: UpdateActorDto) {
        await apiClient.update('1.0', actor);
        console.log('Actor is updated.');
        setTimeout(getActors, 100);
    }

    async function deleteActor(actorId: number) {
        await apiClient.delete(actorId, "1.0");
        console.log('Actor is deleted.');
        setTimeout(getActors, 100);
    }

    async function getActors() {
        const actorListVm = await apiClient.getAll('1.0');
        setActors(actorListVm.actors);
        
    }
    async function getActor(id: number) {
        const actorDetailsVm = await apiClient.get(id, '1.0');  
        setActorDetails(actorDetailsVm);
    }
   
    useEffect(() => {
        setTimeout(getActors, 100);
    }, []);

    const handleDelete = async (actorId: number) => {
        await deleteActor(actorId);
        setTimeout(getActors, 100);
    }; 

    return (
        <div className='block'>
            <div className="title">
                Actors
            </div> 
            <div>
                Actor first name: <FormControl ref={textInput1}/>
                Actor last name: <FormControl ref={textInput2}/>  
                id of actor(for update) <FormControl ref={textInput3}/>  
            </div> 
            <section>
                {actors?.map((actor ) => (
                    <div key={actor.id} className="item">
                        {actor.firstName} {actor.lastName} 
                        <div className="btns"> 
                            <Button className="buttonClass" onClick={() => handleDelete(actor.id ?? 0 )}>Delete</Button> 
                            <Button className="buttonClass" onClick={() => getActor(actor.id ?? 0)}>View Details</Button> 
                        </div>
                    </div>  
                ))}
            </section> 
            <div className="details">
                {actorDetails && (
                    <div >
                        <h2> {actorDetails.firstNane} {actorDetails.lastName}</h2>
                        <p>Id: {actorDetails.id}</p> 
                        <p>Films:</p>
                        {actorDetails.films && actorDetails.films.map((film, index) => (
                            <div key={index}>
                            <p>{film.title}</p>
                            </div>
                        ))}
                    </div>
                )}
            </div>
            <Button  className="buttonClass" onClick={() => createActor({firstName: textInput1.current?.value, lastName: textInput2.current?.value})}>
                Add Actor
            </Button>
            <Button  className="buttonClass" onClick={() => updateActor({firstName: textInput1.current?.value, lastName: textInput2.current?.value, 
                id:parseInt(textInput3.current?.value ?? '')})}>
                Update Actor
            </Button> 
        </div>
    );
};

 
export default ActorList;