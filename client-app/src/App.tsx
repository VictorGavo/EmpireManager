import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';

function App() {
  const [territories, setTerritories] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5000/api/territories')
    .then(response => {
      setTerritories(response.data);
    });
  }, []);

  return (
    <div>
      <h1>Territories</h1>
      <ul>
        {/* {territories.map((territory)) => {
        <li key={territory.id}>
          {territory.name}
        </li>
        }} */}
      </ul>
    </div>
  )
}

export default App
