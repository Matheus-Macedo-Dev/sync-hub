import axios from 'axios'

const baseApiUrl: string = import.meta.env.VITE_APP_API_URL;

const api = axios.create({
  baseURL: baseApiUrl, 
})


export default api
