import React, { useState } from "react";
import { useQuery, gql } from "@apollo/client";
import {
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  ListItemAvatar,
  Typography,
  Box,
} from "@mui/material";
import WidgetsIcon from "@mui/icons-material/Widgets";
import NumbersIcon from '@mui/icons-material/Numbers';
import AttachMoneyIcon from '@mui/icons-material/AttachMoney';
import CategoryIcon from '@mui/icons-material/Category';

const GET_PRODUCTS = gql`
  query GetProducts {
    products(
      first: 50
      where: { isActive: { eq: true }, isSellable: { eq: true } }
      order: [{ sku: ASC }]
    ) {
      totalCount
      pageInfo {
        hasNextPage
        hasPreviousPage
        startCursor
        endCursor
        __typename
      }
      edges {
        node {
          id
          sku
          name
          description
          unitMsrp
          productAttributes {
            productAttributeType {
              code
              name
              isActive
              __typename
            }
            value
            __typename
          }
          __typename
        }
        cursor
        __typename
      }
      __typename
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
          {selectedProductId === node.id && (
            <Box marginLeft={7}>
              <List disablePadding>
                <ListItem>
                  <ListItemAvatar>
                    <NumbersIcon />
                  </ListItemAvatar>
                  <ListItemText
                    primary="SKU"
                    secondary={node.sku}
                  ></ListItemText>
                </ListItem>
                <ListItem>
                  <ListItemAvatar>
                    <AttachMoneyIcon />
                  </ListItemAvatar>
                  <ListItemText
                    primary="Unit MSRP"
                    secondary={node.unitMsrp}
                  ></ListItemText>
                </ListItem>
                {node.productAttributes.map((attr, index) => (
                  <ListItem key={index}>
                    <ListItemAvatar>
                      <CategoryIcon />
                    </ListItemAvatar>
                    <ListItemText
                      primary={attr.productAttributeType.name}
                      secondary={attr.value}
                    ></ListItemText>
                  </ListItem>
                ))}
              </List>
            </Box>
          )}
        </div>
      ))}
    </List>
  );
}

export default ProductList;
