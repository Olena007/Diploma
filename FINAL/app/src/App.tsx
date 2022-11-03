import './App.css';
import { BrowserRouter, Link, Outlet, Route, Routes, useNavigate, useParams } from 'react-router-dom';
import { Button, Card } from 'react-bootstrap';
import Basket from './components/DisplayCards/BasketCards/BasketCard';
import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import { isTemplateSpan } from 'typescript';

import Catalog from './components/Catalog/Catalog';
import Phone from './components/DisplayCards/PhoneCards/PhoneCard';
import Computer from './components/DisplayCards/ComputerCards/ComputerCard';
// import PhoneId from './components/DisplayCards/PhoneCards/PhoneById';

import Login from './components/Login/Login';

import GetById from "./components/DisplayCards/PhoneCards/PhoneGetById";
import Register from './components/Register/Register';
import Header from './components/Header/Header';
import GetByIdComp from './components/DisplayCards/ComputerCards/ComputerGetById';
import C from './components/DisplayCards/ComputerCards/id';
// import Compall from './components/DisplayCards/ComputerCards/PhoneCards/PhoneCard';

import Computerr from './components/DisplayCards/ComputerCardss/CompCard';
import History from './components/DisplayCards/HistoryCards/HistoryCard';

// type User = { name: string };




function App() {
  const [element, setElement] = useState([]);

  const [name, setName] = useState('');
  //console.log("start ");
  //console.log("app1 ", name);

  useEffect(() => {
    (
        async () => {
            const response = await fetch('http://localhost:7169/api/client', {
                method: 'GET',
                headers: {'Content-Type': 'application/json'},
                credentials: 'include',
            });

            const content = await response.json();

           // console.log("content ", content);

            setName(content.email);

            //console.log("app2 ", name);
        }
    )();
});

        //console.log("NAME - ", name);

        
  // const handlerBasket = (item : never) => {
  //     element.push(item);
  //     console.log('working');
  // }

  
  return (
    <div className="App">
      <Header name={name} setName={setName}/>
         <Routes>
            <Route path="/" element={<HomePage name = {name} />}></Route>

            <Route path="catalog" element={<Catalog />}></Route>
            <Route path="login" element={<Login setName={setName}/>}></Route>
            <Route path="register" element={<Register />}></Route>
            <Route path="*" element={<NoMatchComponent />} />

            <Route path="phones" element={<Phone />}></Route>
            <Route path="/phones/:id" element={<GetById />}/>

            <Route path="computers" element={<Computer />}></Route>
            <Route path="/computers/:id" element={<GetByIdComp />}/>

            <Route path="basket" element={<Basket name = {name}/>} ></Route>
            <Route path="history" element={<History />}></Route>
          </Routes>
    </div>
  );
}

function HomePage(props : {name: string}) {
  const navigation = useNavigate();

  return(
    <div>
      {props.name ? 'Hi ' + props.name : 'You are not logged in'}
        MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE MAIN PAGE 
    </div>
  );
}

const NoMatchComponent = () => {
  return (
    <div>
      <h2>Nothing to see here!</h2>
      <p>
        <Link to="/">Go to the home page</Link>
      </p>
    </div>
  );
}

export default App;
