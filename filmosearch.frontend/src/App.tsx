import { FC, ReactElement } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import userManager, { loadUser, signinRedirect } from './auth/user-service';
import { signoutRedirect } from './auth/user-service';
import AuthProvider from './auth/auth-provider';
import SignInOidc from './auth/SigninOidc';
import SignOutOidc from './auth/SignoutOidc';
import ActorList from './actors/ActorList';  
import FilmList from './films/FilmList';  
import ReviewList from './reviews/ReviewList';  
import ActorFilmList from './actorfilms/AddFilmToActor';  
 
    
const App: FC<{}> = (): ReactElement => {
    loadUser();
    return (
        <div className="App">
            <header className="App-header"> 
                <div className="siteName">FilmoSearch</div>
                <div className="header-btns">
                    <button className="buttonClass" onClick={() => signinRedirect()}>Login</button> 
                    <button className="buttonClass" onClick={() => signoutRedirect()}>Logout</button> 
                </div> 
                
            </header>
            <AuthProvider userManager={userManager}>
                    <Router>
                        <Routes>

                            <Route  path="/" element={<div><ActorList/><FilmList/><ReviewList/><ActorFilmList/></div>} />
                            
                            <Route
                                path="/signout-oidc"
                                element={<SignOutOidc/>}
                            />
                        <Route path="/signin-oidc" element={<SignInOidc/>} />
                    </Routes>
                </Router>
            </AuthProvider> 
        </div>
    );
};

export default App;