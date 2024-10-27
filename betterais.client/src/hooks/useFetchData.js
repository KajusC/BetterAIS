import { useState, useEffect } from 'react';
import axios from 'axios';

export const useFetchData = (endpoint) => {
  const [data, setData] = useState([]);

  useEffect(() => {
    axios.get(endpoint).then((response) => {
      setData(response.data);
    });
  }, [endpoint]);

  return { data };
};
