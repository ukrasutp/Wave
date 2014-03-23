CREATE OR REPLACE FUNCTION public.__user_login(login text, password text)
RETURNS integer AS
$BODY$
DECLARE
  la integer;
BEGIN
  la = -1;
  SELECT  levelaccess INTO la
  FROM   public.users
  WHERE  login = $1 AND password = $2;
  RETURN la;
EXCEPTION
  WHEN others THEN
    BEGIN
      INSERT INTO public.sql_errors(func_name, error_time, error_text)
      VALUES ('__user_login', now(), SQLERRM);
      RETURN -1;
    END;
  
END;
$BODY$
  LANGUAGE plpgsql;
COMMENT ON FUNCTION public.__user_login(text, text) IS 'Вход пользователя';