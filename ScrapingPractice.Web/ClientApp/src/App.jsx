import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';

const App = () => {

    const [items, setItems] = useState([]);

    useEffect(() => {

        const GetItems = async () => {
            const { data } = await axios.get("/api/scraper/scrape");
            setItems(data);
        }

        GetItems();
    }, []);


    return (
        <div className='container mt-5'>
           
            <div className='row mt-3'>
                <table className='table table-bordered'>
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Title</th>
                            <th>Content</th>
                            <th>Comment Count</th>

                        </tr>
                    </thead>
                    <tbody>
                        {items.map(item => {
                            return <tr key={item.url}>
                                <td><img src={item.image} style={{ width: 100 }} /></td>
                                <td>
                                    <a target="_blank" href={item.url}>{item.title}</a>
                                </td>
                                <td>
                                    {item.content}
                                </td>
                                <td>
                                    {item.comments}
                                </td>
                            </tr>
                        })}
                    </tbody>
                </table>
            </div>
        </div>
    )


};

export default App;