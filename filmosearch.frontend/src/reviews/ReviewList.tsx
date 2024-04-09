import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateReviewDto, Client, ReviewLookupDto, UpdateReviewDto, ReviewDetailsVm } from '../api/api';
import { FormControl } from 'react-bootstrap';
import { Button } from 'react-bootstrap';
const apiClient = new Client('https://localhost:44364');
 
const ReviewList: FC<{}> = (): ReactElement => {
    let reviewTitle = useRef<HTMLInputElement>(null);
    let reviewDescription = useRef<HTMLInputElement>(null);
    let rviewStars = useRef<HTMLInputElement>(null);
    let filmId = useRef<HTMLInputElement>(null);
    let reviewId = useRef<HTMLInputElement>(null);
    const [reviews, setReviews] = useState<ReviewLookupDto[] | undefined>(undefined);
    const [reviewDetails, setReviewDetails] = useState<ReviewDetailsVm | undefined>(undefined);

    async function createReview(review: CreateReviewDto) {
        await apiClient.create3('1.0', review);
        console.log('Review is created.');
        setTimeout(getReviews, 100);
    } 

    async function deleteReview(reviewId: number) {
        await apiClient.delete4(reviewId, "1.0");
        console.log('Review is deleted.'); 
        setTimeout(getReviews, 100);
    } 
    async function updateReview(review: UpdateReviewDto) {
        await apiClient.update3('1.0', review);
        console.log('Review is updated.');
        setTimeout(getReviews, 100);
    }


    async function getReviews() {
        const filmListVm = await apiClient.getAll3('1.0');
        setReviews(filmListVm.reviews);
        
    }
    async function getReview(id: number) {
        const reviewDetailsVm = await apiClient.get3(id, '1.0');  
        setReviewDetails(reviewDetailsVm);
    }

    useEffect(() => {
        setTimeout(getReviews, 100);
    }, []); 

    return (
        <div className='block'>
            <div className="title">
                Reviews
            </div>
            
            <div>
                Review title: <FormControl ref={reviewTitle}/>
                Review description: <FormControl ref={reviewDescription}/>
                Review stars: <FormControl ref={rviewStars}/>
                Film id(for create): <FormControl ref={filmId}/>
                Review id(for update): <FormControl ref={reviewId}/>
            </div>
            <section>
                {reviews?.map((review ) => (
                    <div className="item" key={review.id} >
                        {review.title} {review.description} {review.stars} {review.film?.title}     
                        <div className="btns">
                            <Button className="buttonClass" onClick={() => deleteReview(review.id ?? 0 )}>Delete</Button>  
                            <Button className="buttonClass" onClick={() => getReview(review.id ?? 0)}>View Details</Button> 
                        </div>
                    </div>  
                ))}
            </section> 
            <div className="details">
                {reviewDetails && (
                    <div>
                        <h2> {reviewDetails.title}</h2>
                        <p>Id: {reviewDetails.id}</p> 
                        <p>Film: {reviewDetails.film}</p> 
                        <p>Film stars: {reviewDetails.stars}</p> 
                        <p>Film description: {reviewDetails.description}</p>  
                    </div>
                )}
            </div>
            <Button className="buttonClass" onClick={() => createReview({
                    title: reviewTitle.current?.value,
                    description: reviewDescription.current?.value,
                    stars: parseInt(rviewStars.current?.value ?? ''),
                    filmId: parseInt(filmId.current?.value ?? '')})}>
                Add Review
            </Button>
            <Button className="buttonClass" onClick={() => updateReview({
                    title: reviewTitle.current?.value,
                    description: reviewDescription.current?.value,
                    stars: parseInt(rviewStars.current?.value ?? ''),
                    id:parseInt(reviewId.current?.value ?? '') })}>
                Update Review
            </Button>
        </div>
    );
};

 
export default ReviewList;
