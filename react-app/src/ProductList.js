import React, { useState } from "react";
import { useQuery, gql } from "@apollo/client";
import {
  List,
  ListItemButton,
  ListItemText,
  ListItemAvatar,
} from "@mui/material";
import WidgetsIcon from "@mui/icons-material/Widgets";

import ProductDetail from './ProductDetail';

const GET_PRODUCTS = gql`
  query GetProducts {
    products(
      first: 50
      where: { isActive: { eq: true }, isSellable: { eq: true } }
      order: [{ name: ASC }]
    ) {
      totalCount
      edges {
        node {
          id
          name
          description
        }
      }
    }
  }
`;

function ProductList() {
  const { loading, error, data } = useQuery(GET_PRODUCTS);
  const [selectedProductId, setSelectedProduct] = useState(null);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :</p>;

  const handleClick = (product) => {
    setSelectedProduct(product);
  };

  console.log(data);

  return (
    <List>
      {data.products.edges.map(({ node }) => (
        <div key={node.id}>
          <ListItemButton onClick={() => handleClick(node.id)}>
            <ListItemAvatar>
              <WidgetsIcon />
            </ListItemAvatar>
            <ListItemText primary={node.name} secondary={node.description} />
          </ListItemButton>
          {selectedProductId === node.id && <ProductDetail node={node} />}
        </div>
      ))}
    </List>
  );
}

export default ProductList;
