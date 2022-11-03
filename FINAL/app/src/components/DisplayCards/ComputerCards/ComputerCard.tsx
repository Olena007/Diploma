import React, { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import Computers from './ComputerTemplate';
import Sort from './Sorting';

interface IComputer{
    computerId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

function ComputerCard () {
    const [comps, setDisplay] = useState<IComputer[]>([]);
    const [compsName, setDisplayName] = useState<IComputer[]>([]);
    const [compsDesc, setDisplayDesc] = useState<IComputer[]>([]);
    const [compsAsce, setDisplayAsce] = useState<IComputer[]>([]);
    const [loading, setLoading] = useState(false);
    const [currentPage, setCurrent] = useState(1);
    const [compsPerPage] = useState(5);
    const [search, setSearch] = useSearchParams();


    useEffect(() => {
        const fetchGetAll = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Computer')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplay(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetAll();
         

    }, []);


    useEffect(() => {
        const fetchGetName = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Computer/byName')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplayName(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetName();
         

    }, []);

    useEffect(() => {
        const fetchGetDesc = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Computer/priseDesc')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplayDesc(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetDesc();
    }, []);

    useEffect(() => {
        const fetchGetAsce = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Computer/priseAsce')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplayAsce(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetAsce();
    }, []);

    const indexOfLastPhone = currentPage * compsPerPage;
    const indexOfFirstPhone = indexOfLastPhone - compsPerPage;
    const currentPhone = comps.slice(indexOfFirstPhone, indexOfLastPhone);
    const currentPhoneName = compsName.slice(indexOfFirstPhone, indexOfLastPhone);
    const currentPhoneDesc = compsDesc.slice(indexOfFirstPhone, indexOfLastPhone);
    const currentPhoneAsce = compsAsce.slice(indexOfFirstPhone, indexOfLastPhone);


    const paginate = (pageNumber : number) => setCurrent(pageNumber);

    function pag (pageNumber : number){
        setCurrent(pageNumber);
    }

    function Pagination (postPerPage : number, totalPost : number){
        const pageNumbers = [];
    
    
        for(let i = 1; i <= Math.ceil(totalPost / postPerPage); i++){
            pageNumbers.push(i);
        }
    
        return(
            <nav>
                <ul className="pagination">
                    {pageNumbers.map(number => (
                        <li key={number} className="page-item">
                            <a onClick={() => pag(number)} className="page-link">{number}</a>
                        </li>
                    ))}
                </ul>
            </nav>
        );
    }


    let url = window.location.href;
    let menu;
    if (url === "http://localhost:3000/computers?set=name" ) {
        menu = (
            <>{Computers(currentPhoneName, loading)}</>
        )
    }
    else 
    if (url === "http://localhost:3000/computers"){
        menu = (
            <>{Computers(currentPhone, loading)}</>
        ) 
    }
    else
    if (url === "http://localhost:3000/computers?set=suggested"){
        menu = (
            <>{Computers(currentPhone, loading)}</>
        ) 
    }
    else
    if (url === "http://localhost:3000/computers?set=priceDesc"){
        menu = (
            <>{Computers(currentPhoneDesc, loading)}</>
        ) 
    }
    else
    if (url === "http://localhost:3000/computers?set=priceAsc"){
        menu = (
            <>{Computers(currentPhoneAsce, loading)}</>
        ) 
    }
    return(
        <div className="phone-list">
            <h1>List Computers</h1>

            <Sort options={[
            {
                label: 'Suggested',
                value: 'suggested',
            },
            {
              label: 'Name',
              value: 'name',
            },
            {
              label: 'Price From High To Low',
              value: 'priceDesc',
            },
            {
              label: 'Price From Low To High',
              value: 'priceAsc',
            },
          ]} label = {"Sort by"} name={"sort"} defaultValue={''} onChange={(e) => {search.set('set', e.target.value);
          setSearch(search, {replace: true})}}

           />
            {menu}

            
            {Pagination(compsPerPage, comps.length)}
        </div>
    );
    
    
}

export default ComputerCard;