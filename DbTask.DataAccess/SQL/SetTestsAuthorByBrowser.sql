UPDATE test SET author_id = @AuthorId
OUTPUT INSERTED.id
WHERE browser = @Browser