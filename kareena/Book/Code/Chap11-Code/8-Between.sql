SET QUOTED_IDENTIFIER OFF
SELECT Description,CurrentPrice 
  FROM ShareDetails.Shares
WHERE Description BETWEEN 'Mackrel Fisheries'
AND "Toland's Irish"
