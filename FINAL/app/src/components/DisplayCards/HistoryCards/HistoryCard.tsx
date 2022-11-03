import Reacts, { useEffect, useState } from "react";
import { Card, ListGroup } from "react-bootstrap";
import { reduceEachTrailingCommentRange } from "typescript";
import Hst from './HistoryDefine';
import HistComp from './HistoryCompDefine';

interface IHistory {
    historyId: number,
    basketId : number
    basketCompId : number
}

interface IPhone {
    historyId: number,
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

interface IBasket {
    basketId: number,
    phoneId : number,
    clientId: number
}

interface IBasketComp {
    basketId: number,
    computerId : number,
    clientId: number
}

interface IComputer {
    historyId: number,
    computerId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

export default function History(){
    const [history, setDisplay] = useState<IHistory[]>([]);
    const [basketHis, setBas ] = useState<IBasket[]>([]);
    const [phones, setPhone ] = useState<IPhone[]>([]);
    const [basketComp, setBasComp ] = useState<IBasketComp[]>([]);
    const [computers, setComp ] = useState<IComputer[]>([]);




    useEffect(() => {
        const fetchGetAll = async () => {

        fetch('http://localhost:7169/History')
            .then(response => response.json())
            .then(added => {
                setDisplay(added);
            })
            .catch((error) => {
                console.log(error);
            }); 
        }
        fetchGetAll();

        
    }, []);

    //console.log("history", history);
    var arr: Array<any> = [];
    var arrComp: Array<any> = [];
    let c = 0;

    useEffect(() => {
        const GetBasket = async() : Promise<Array<any>>   => {
            for (let i = 0; i < history.length; i ++){

                const res: Response =  await fetch(`http://localhost:7169/Basket/${history[i].basketId}`);
                //sconsole.log("id ", history[i].basketId);
                const body = await res.json();

    
                const ent = Object.values(body);
                arr.push(body);
                //console.log("arr el ", arr[i]);

                
            } 
            setBas(arr);
            return basketHis;
         }
         
        GetBasket();
    },[history.length]);

    useEffect(() => {
        const GetBasketComp = async() : Promise<Array<any>>   => {
            for (let i = 0; i < history.length; i ++){

                if (history[i].basketCompId != null){
                    const res: Response =  await fetch(`http://localhost:7169/BasketComp/${history[i].basketCompId}`);
                console.log("id ", history[i].basketId);
                const body = await res.json();

    
                const ent = Object.values(body);
                arrComp.push(body);
                }
                
                //console.log("arr el ", arr[i]);

                
            } 
            setBasComp(arrComp);
            return basketHis;
         }
         
        GetBasketComp();
    },[history.length]);

   // console.log("basket comp ", basketComp);

    //console.log("arr ", phones);

    var arrp: Array<any> = [];
    var arrpComp: Array<any> = [];

    useEffect(() => {
        const GetPhone = async() : Promise<Array<any>>   => {
            
            for (let i = 0; i < basketHis.length; i ++){

                //console.log("b ", basketHis[i]);
                const res: Response =  await fetch(`http://localhost:7169/Phone/${basketHis[i].phoneId}`);
                const body = await res.json();

    
                const ent = Object.values(body);
                //console.log("phone ", body);

                arrp.push(body);
                
                
            } 
            setPhone(arrp);
            return phones;
         }
         
        GetPhone();
    },[basketHis.length + basketHis.length]);


    useEffect(() => {
        const GetComp = async() : Promise<Array<any>>   => {
            
            for (let i = 0; i < basketComp.length; i ++){

                //console.log("b ", basketHis[i]);
                const res: Response =  await fetch(`http://localhost:7169/Computer/${basketComp[i].computerId}`);
                const body = await res.json();

    
                const ent = Object.values(body);
                //console.log("phone ", body);

                arrpComp.push(body);
                
                
            } 
            setComp(arrpComp);
            return phones;
         }
         
        GetComp();
    },[basketComp.length + basketComp.length]);
    //console.log("computers ", computers);
    //console.log("check 3 phones length ", phones.length);

//     let conct: Array<any> = [];
//     let conct2: Array<any> = [];

//    conct2 = phones;

//     for(let i = 0; i < history.length; i++){
//         conct[i] = history[i].historyId;
//     }

//     for(let i = 0; i < conct2.length; i++){
//         conct2[i].historyId = conct[i];
//     }


//     console.log("history ", history);
//     console.log("basket ", basketHis);
//     console.log("phones ", phones);
    
//     console.log("cnct  ", conct);
//     console.log("cnct2  ", conct2);

    return(
        //<div>j</div>
        <>
        {HistComp(computers)}
        {Hst(phones)}
        </>
    );
}