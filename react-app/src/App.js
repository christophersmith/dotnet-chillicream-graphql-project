import "./App.css";
import { ApolloProvider } from '@apollo/client';
import client from './apollo';
import "./ProductList"
import ProductList from "./ProductList";

function App() {
  return (
    <ApolloProvider client={client}>
      <div className="App">
        <ProductList></ProductList>
      </div>
    </ApolloProvider>
  );
}

export default App;
