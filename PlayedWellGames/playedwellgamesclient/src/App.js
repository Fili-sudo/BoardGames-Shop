import logo from './logo.svg';
import './App.css';
import SearchAppBar from './components/SearchAppBar';
import ImgMediaCard from './components/MediaCard';
import ProductCards from './components/ProductCards';
import BasicPagination from './components/Pagination';
import SelectFilled from './components/Select';
import { useEffect, useState } from "react";
import axios from 'axios';

function App() {

  const [products, setProducts] = useState([]);
  const [filteredProducts, SetFilteredProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [productsPerPage] = useState(6);
  const [orderByState, SetOrderByState] = useState("");
  const [changedOrderRule, SetChangedOrderRule] = useState(true);

  useEffect(() => {
    const fetchPosts = async () => {
      setLoading(true);
      const res = await axios.get('https://localhost:7020/api/Products');
      setProducts(res.data);
      SetFilteredProducts(res.data.slice());
      setLoading(false);
    };

    fetchPosts();
  }, []);


  const paginate = pageNumber => setCurrentPage(pageNumber)
  const orderRule = rule => { SetOrderByState(rule); SetChangedOrderRule(false); }
  const updateProducts = () => {
    if(orderByState == "By price" && !changedOrderRule){
      SetChangedOrderRule(true);
      SetFilteredProducts(filteredProducts.sort((a, b) => a.price <= b.price? -1: 1 ))
    }
    else if (orderByState == "Alphabetically" && !changedOrderRule){
      SetChangedOrderRule(true);
      SetFilteredProducts(filteredProducts.sort((a, b) => a.productName <= b.productName? -1: 1 ))
    }
    else if (!changedOrderRule){
      SetChangedOrderRule(true);
      SetFilteredProducts(products.slice());
    }
  }
   
  
  updateProducts();
  const indexOfLastProduct = currentPage * productsPerPage;
  const indexOfFirstProduct = indexOfLastProduct - productsPerPage;
  const currentProducts = filteredProducts.slice(indexOfFirstProduct, indexOfLastProduct);

  

  return (
    <div>
      <header>
        <h1>
          Played Well Games
        </h1>
        <SearchAppBar/>
      </header>
      <SelectFilled orderRule = {orderRule} />
      <ProductCards products={currentProducts} loading={loading} />
      <BasicPagination
        productsPerPage = {productsPerPage}
        totalProducts = {products.length}
        paginate = {paginate}
      />
    </div>
    
    
  );
}

export default App;
