import logo from './logo.svg';
import './App.css';
import SearchAppBar from './components/SearchAppBar';
import ImgMediaCard from './components/MediaCard';
import ProductCards from './components/ProductCards';
import BasicPagination from './components/Pagination';
import { useEffect, useState } from "react";
import Posts from './components/Posts';
import axios from 'axios';

function App() {

  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [productsPerPage] = useState(1);

  useEffect(() => {
    const fetchPosts = async () => {
      setLoading(true);
      const res = await axios.get('https://localhost:7020/api/Products')
      setProducts(res.data);
      setLoading(false);
    };

    fetchPosts();
  }, []);

  const indexOfLastProduct = currentPage * productsPerPage;
  const indexOfFirstProduct = indexOfLastProduct - productsPerPage;
  const currentProducts = products.slice(indexOfFirstProduct, indexOfLastProduct);

  const paginate = pageNumber => setCurrentPage(pageNumber);

  return (
    <div>
      <header>
        <h1>
          Played Well Games
        </h1>
        <SearchAppBar/>
      </header>
      <ProductCards products={currentProducts} loading={loading} />
      <Posts posts={currentProducts} loading={loading} />
      <BasicPagination
        productsPerPage = {productsPerPage}
        totalProducts = {products.length}
        paginate = {paginate}
      />
    </div>
    
    
  );
}

export default App;
